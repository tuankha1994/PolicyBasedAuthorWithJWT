using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Models
{
    public class AccountLoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public class LoginResultModel
    {
        public string Status { get; set; }
        public string AccessToken { get; set; }
        public string Username { get; set; }
        public Role Role { get; set; }
        public List<string> Permissions { get; set; }
    }
  
    public enum LoginStatus
    {
        Success,
        Fail,
        IsActive
    }
}
