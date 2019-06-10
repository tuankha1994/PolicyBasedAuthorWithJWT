using Business.Models;
using Business.Utils;
using Data.DataTest;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Business.Utils.JWTHelper;

namespace Business.Services
{
    public interface ICoreService
    {
        LoginResultModel Authenticate(JWTInfoModel loginInfo);
        List<Permission> GetPermissionsByRoleId(long roleId);
        string GetRoleNameByRoleId(long roleId);
    }
    public class CoreService : ICoreService
    {
        public LoginResultModel Authenticate(JWTInfoModel loginInfo)
        {
            var loginResult = new LoginResultModel();
            var userlogin = DataTest.UserList.FirstOrDefault(x => x.Username.ToUpper() == loginInfo.Username.ToUpper() && x.Password == loginInfo.Password);
            if (userlogin == null)
            {
                loginResult.Status = LoginStatus.Fail.ToString();
            }
            else
            {
                var role = DataTest.RoleList.FirstOrDefault(x => x.Id == userlogin.RoleId);
                var listPermission = DataTest.PermissionList.Where(x => x.RoleId == userlogin.RoleId)
                    .Select(x => x.Function)
                    .ToList();
                loginInfo.RoleId = userlogin.RoleId;

                var jwtToken = JWTHelper.BuildToken(loginInfo);

                loginResult.Status = LoginStatus.Success.ToString();
                loginResult.Username = userlogin.Username;
                loginResult.Role = role;
                loginResult.Permissions = listPermission;
                loginResult.AccessToken = jwtToken;
            }

            return loginResult;
        }

        public List<Permission> GetPermissionsByRoleId(long roleId)
        {
            var listPermission = DataTest.PermissionList.Where(x => x.RoleId == roleId).ToList();
            return listPermission;
        }

        public string GetRoleNameByRoleId(long roleId)
        {
            var roleName = DataTest.RoleList.FirstOrDefault(x => x.Id == roleId)?.Name;
            return roleName;
        }
    }
}
