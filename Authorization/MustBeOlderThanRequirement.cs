using Microsoft.AspNetCore.Authorization;

namespace WindowsAuth.Authorization
{
    public class MustBeOlderThanRequirement : IAuthorizationRequirement
    {
        public int MustBeOlderThanRequired { get; set; }

        public MustBeOlderThanRequirement(int mustBeOlderThanRequired)
        {
            MustBeOlderThanRequired = mustBeOlderThanRequired;
        }
    }
}
