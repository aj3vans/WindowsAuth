using Microsoft.AspNetCore.Authorization;

namespace WindowsAuth.Authorization
{
    public class IsAccountOwnerRequirement : IAuthorizationRequirement
    {        

        public IsAccountOwnerRequirement()
        {
          
        }
    }
}
