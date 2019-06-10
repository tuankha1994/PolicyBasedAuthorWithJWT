using Data.DataTest;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utils
{
    public class PermissionRequirement : IAuthorizationRequirement
    {
        public PermissionRequirement(string policy)
        {
            Policy = policy;
        }
        public string Policy { get; }
    }

    public class PermissionHandler : AuthorizationHandler<PermissionRequirement>
    {
        private bool CanAccess(string policy, AuthorizationHandlerContext context)
        {
            if (context.User == null)
            {
                return false;
            }

            if (string.IsNullOrEmpty(policy))
            {
                return true;
            }

            var userRoleId = DataTest.UserList.FirstOrDefault(x => x.Username.ToUpper() == context.User.Identity.Name?.ToUpper())?.RoleId;
            var isFullPermission = DataTest.PermissionList.Where(x => x.RoleId == userRoleId && x.Function == PermissionRegister.FullPermissions).Any();
            if (isFullPermission) { return true; }

            var permission = DataTest.PermissionList.Where(x => x.Function == policy);
            var userHasPermission = permission.Any(x => x.RoleId == userRoleId);

            return userHasPermission;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            if (CanAccess(requirement.Policy, context))
            {
                context.Succeed(requirement);
            }
            await Task.CompletedTask;
        }
    }
}
