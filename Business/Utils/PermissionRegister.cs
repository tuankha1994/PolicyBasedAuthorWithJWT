using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Business.Utils
{
    public static class PermissionRegister
    {
        public const string FullPermissions = "FullPermissions";
        public const string GetProduct = "GetProduct";
        public const string AddProduct = "AddProduct";
        public const string UpdateProduct = "UpdateProduct";
        public const string DeleteProduct = "DeleteProduct";

        public static List<string> GetListPermission()
        {
            Type registerType = typeof(PermissionRegister);
            List<string> listConst = registerType
                .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                .Where(fi => fi.IsLiteral && !fi.IsInitOnly && fi.FieldType == typeof(string))
                .Select(x => (string)x.GetRawConstantValue())
                .ToList();

            return listConst;
        }
    }
}
