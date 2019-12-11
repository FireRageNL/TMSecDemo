using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using APIDemo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiNoRequestLimit.Controllers
{
    [ApiController]
    [Route("login")]
    public class LoginController : ControllerBase
    {

        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        [HttpGet("default/{toEncrypt}")]
        public ActionResult Post(string toEncrypt)
        {
            return Ok(Hash.GenerateUnsafeHash(toEncrypt));
        }

        [HttpGet("salted/{toEncrypt}")]
        public ActionResult PostSafe(string toEncrypt)
        {
            return Ok(Hash.GenerateHash(toEncrypt));
        }

        [HttpGet("limited/{toEncrypt}")]
        public ActionResult PostLimited(string toEncrypt)
        {
            return Ok(Hash.GenerateHash(toEncrypt));
        }
    }
}
