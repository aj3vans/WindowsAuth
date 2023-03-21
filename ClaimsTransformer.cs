using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Caching.Memory;
using System.Security.Claims;
using System.Security.Principal;
using WindowsAuth.Interfaces;

#nullable disable

namespace WindowsAuth
{
    public class ClaimsTransformer : IClaimsTransformation
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserPermissionRepository _userPermissionRepository;
        private readonly IMemoryCache _cache;

        public ClaimsTransformer(
            IUserRepository userRepository, 
            IUserPermissionRepository userPermissionRepository,
            IMemoryCache cache)
        {
            _userRepository = userRepository;   
            _userPermissionRepository = userPermissionRepository;
            _cache = cache;
        }
        //--

        /*
            Provides a central transformation point to change the specified principal. 
            Note: this will be run on each AuthenticateAsync call, so its safer to return a new ClaimsPrincipal if your transformation is not idempotent. 
        */
        public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            // get current claims identity 
            var identity = (ClaimsIdentity)principal.Clone().Identity;
            var sAMAccountName = identity.Name.Split(@"\")[1];

            if (_cache.TryGetValue(sAMAccountName, out ClaimsIdentity claimsIdentity))
            {
                // replace current claims identity with cached version               
                principal = new ClaimsPrincipal(claimsIdentity);

                return Task.FromResult(principal);
            }
            else
            {
                // get  user | user permissions
                var user = _userRepository.GetBysAMAccountName(sAMAccountName);
                var userPermissions = _userPermissionRepository.GetBysAMAccountName(sAMAccountName);

                identity.AddClaim(new Claim("UserId", user.UserId.ToString()));
                identity.AddClaim(new Claim("Username", sAMAccountName));
                identity.AddClaim(new Claim("DateOfBirth", user.DateOfBirth.ToShortDateString()));

                // add permissions 
                foreach (var userPermission in userPermissions)
                {
                    // add roles            
                    if (userPermission.Type.Equals("Role"))
                    {
                        identity.AddClaim(new Claim(identity.RoleClaimType, userPermission.Name));
                    }

                    // add claims
                    if (userPermission.Type.Equals("Permission"))
                    {
                        identity.AddClaim(new Claim("Permission", userPermission.Name));
                    }
                }
                               
                // save claims identity in memory cache 
                _cache.Set(sAMAccountName, identity, DateTime.Now.AddHours(12));

                return Task.FromResult(principal);
            }
        }
    }
}
