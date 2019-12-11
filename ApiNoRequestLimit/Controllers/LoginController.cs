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

        [HttpGet("default")]
        public ActionResult Post(string toEncrypt, int amount)
        {
            string[] hashes = new string[amount];
            for(int i = 0; i < amount; i++)
            {
                hashes[i] = Hash.GenerateUnsafeHash(toEncrypt);
            }
            return Ok(String.Join("\n", hashes));
        }

        [HttpGet("salted")]
        public ActionResult PostSafe(string toEncrypt, int amount)
        {
            string[] hashes = new string[amount];
            for(int i = 0; i < amount; i++)
            {
                hashes[i] = Hash.GenerateHash(toEncrypt);
            }
            return Ok(String.Join("\n", hashes));
        }

        [HttpGet("limited")]
        public ActionResult PostLimited(string toEncrypt, int amount)
        {
            string[] hashes = new string[amount];
            for (int i = 0; i < amount; i++)
            {
                hashes[i] = Hash.GenerateHash(toEncrypt);
            }
            return Ok(String.Join("\n", hashes));
        }
    }
}
