using Emp.Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAuth _auth;

        public UserController(IAuth auth)
        {
            _auth = auth;
        }
        [HttpPost]
        public IActionResult Login()
        {
            return new JsonResult(_auth.Autorizar());
        }
    }
}
