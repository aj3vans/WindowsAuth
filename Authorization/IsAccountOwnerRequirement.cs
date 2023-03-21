using Microsoft.AspNetCore.Authorization;

namespace WindowsAuth.Authorization
{
    public class IsAccountOwnerRequirement : IAuthorizationRequirement
    {
        //public int UserId { get; set; }

        public IsAccountOwnerRequirement()//)int userId)
        {
            //this.UserId = userId;
        }
    }
}
