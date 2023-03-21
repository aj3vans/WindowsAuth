using Microsoft.AspNetCore.Authorization;
using WindowsAuth.Models;

#nullable disable

namespace WindowsAuth.Authorization
{
    public class IsAccountOwnerAuthorizationHandler : AuthorizationHandler<IsAccountOwnerRequirement, User>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            IsAccountOwnerRequirement requirement,
            User resource)
        {
            var userId = int.Parse(context.User.FindFirst(c => c.Type.Equals("UserId")).Value);

            if (userId.Equals(resource.UserId))
            {
                context.Succeed(requirement);
            }

            //if (!context.User.HasClaim(c => c.Type.Equals("User.Edit")))
            //{
            //    return Task.CompletedTask;
            //}

            

            //if (userId.Equals(requirement.UserId))
            //{
            //    context.Succeed(requirement);
            //}
            
            return Task.CompletedTask;
        }
    }
}
