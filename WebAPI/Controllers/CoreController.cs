using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Models;
using Business.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using static Business.Utils.JWTHelper;

namespace WebAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class CoreController : ControllerBase
    {
        private readonly ICoreService _iCoreService;
        private readonly IConfiguration _iConfiguration;
        public CoreController(ICoreService iCoreService, IConfiguration config)
        {
            _iConfiguration = config;
            _iCoreService = iCoreService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AccountLoginModel account)
        {

            var jwtInfo = new JWTInfoModel
            {
                Username = account.Username,
                Password = account.Password,
                ExpireTime = DateTime.Now.AddMinutes(long.Parse(_iConfiguration["Jwt:ExpiresInMinutes"])),
                PrivateKey = _iConfiguration["Jwt:PrivateKey"]
            };

            var result = _iCoreService.Authenticate(jwtInfo);

            return Ok(result);
        }
    }
}
