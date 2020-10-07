using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace QLCafe.Application.Controllers
{
    public class LoginController : Controller
    {
        [Route("Login")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
