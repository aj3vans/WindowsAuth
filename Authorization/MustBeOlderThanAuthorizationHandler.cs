using Microsoft.AspNetCore.Authorization;

#nullable disable

namespace WindowsAuth.Authorization
{
    public class MustBeOlderThanAuthorizationHandler : 
        AuthorizationHandler<MustBeOlderThanRequirement>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context, 
            MustBeOlderThanRequirement requirement)
        {
            // check if the claim is present?
            if (!context.User.HasClaim(c => c.Type.Equals("DateOfBirth")))
            {
                return Task.CompletedTask;
            }

            // get the value of the claim 
            var dateOfBirth = DateTimeOffset.Parse(context.User.FindFirst(c => c.Type.Equals("DateOfBirth")).Value);

            // get age
            var mustBeOlderThan = Math.Round((DateTimeOffset.Now - dateOfBirth).TotalDays / 365);

            // check age is older than requirement? 
            if (mustBeOlderThan >= requirement.MustBeOlderThanRequired)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}

