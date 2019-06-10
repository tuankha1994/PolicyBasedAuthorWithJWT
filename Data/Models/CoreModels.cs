using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models
{
    public class User
    {
        [Key]
        public string Username { get; set; }
        public string Password { get; set; }
        public long RoleId { get; set; }
    }

    public class Role
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
    }

    public class Permission
    {
        [Key]
        public long RoleId { get; set; }
        [Key]
        public string Function { get; set; }
    }
}
