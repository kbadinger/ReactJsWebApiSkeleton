using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AdvWeb.Models;
using AdvWeb.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdvWeb.Controllers
{
    public class RegisterController : Controller
    {

        private IUserService _userService;

        public RegisterController(IUserService userService)
        {
            _userService = userService;
        }



        [HttpPost("register")]
        public IActionResult Register(AuthenticateRequest model)
        {
            var response = _userService.Register(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

    }
}
