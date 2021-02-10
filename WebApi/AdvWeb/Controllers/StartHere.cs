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
    public class StartHere : ControllerBase
    {



        [HttpGet("startcall")]
        public IActionResult StartCall()
        {

 
            return Ok( "Successful API call" );
     

    }



        }

}
