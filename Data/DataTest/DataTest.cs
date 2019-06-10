using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DataTest
{
    public class DataTest
    {
        public static List<User> UserList { get; set; } = new List<User>
        {
            new User { Username = "Admin", Password = "123", RoleId = 1},
            new User { Username = "Chaien", Password = "321", RoleId = 2},
            new User { Username = "Lisa", Password = "132", RoleId = 3},
        };

        public static List<Role> RoleList { get; set; } = new List<Role>
        {
            new Role { Id = 1, Name = "SupperAdmin" },
            new Role { Id = 2, Name = "WarehouseAdmin" },
            new Role { Id = 3, Name = "Customer" }
        };

        public static List<Permission> PermissionList { get; set; } = new List<Permission>
        {
            new Permission { RoleId = 1, Function = PermissionRegister.FullPermissions },
            new Permission { RoleId = 2, Function = PermissionRegister.GetProduct },
            new Permission { RoleId = 2, Function = PermissionRegister.AddProduct },
            new Permission { RoleId = 2, Function = PermissionRegister.UpdateProduct },
            new Permission { RoleId = 2, Function = PermissionRegister.DeleteProduct },
            new Permission { RoleId = 3, Function = PermissionRegister.GetProduct },
        };

        private static class PermissionRegister
        {
            public const string FullPermissions = "FullPermissions";
            public const string GetProduct = "GetProduct";
            public const string AddProduct = "AddProduct";
            public const string UpdateProduct = "UpdateProduct";
            public const string DeleteProduct = "DeleteProduct";
        }

        public static List<Product> ProductList { get; set; } = new List<Product>
        {
            new Product { Id = 1, Name = "Product A", Price = 10},
            new Product { Id = 2, Name = "Product B", Price = 20},
            new Product { Id = 3, Name = "Product C", Price = 30},
        };
    }
}
