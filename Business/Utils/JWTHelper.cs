using Business.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Business.Utils
{
    public static class JWTHelper
    {
        public static string BuildToken(JWTInfoModel model)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(model.PrivateKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(ClaimTypes.Name, model.Username),
                new Claim(ClaimTypes.Role, model.RoleId.ToString())
            };

            var token = new JwtSecurityToken(
                expires: model.ExpireTime,
                signingCredentials: credentials,
                claims: claims
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public class JWTInfoModel : AccountLoginModel
        {
            public long RoleId { get; set; }
            public string PrivateKey { get; set; }
            public DateTime ExpireTime { get; set; }
        }

    }
}
