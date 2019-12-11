using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIDemo.Controllers
{
    [Route("bf")]
    [ApiController]
    public class BruteForceController : ControllerBase
    {
        [HttpGet]
        public ActionResult LoginUnfiltered(string Username, string Password)
        {
            return Ok(Hash.VerifyPassword(Username, Password));
        }
        [HttpGet]
        [Route("limited")]
        public ActionResult LoginFiltered(string Username, string Password)
        {
            return Ok(Hash.VerifyPassword(Username, Password));
        }
    }
}