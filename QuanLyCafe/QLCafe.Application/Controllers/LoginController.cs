using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using QLCafe.Application.Models;
using QLCafe.Application.Services;

namespace QLCafe.Application.Controllers
{
  
    public class LoginController : Controller
    {
        private readonly IUserApiClient _userApiClient;
        public LoginController(IUserApiClient userApiClient)
        {
            _userApiClient = userApiClient;
        }
        
       
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromForm]LoginRequest request)
        {
            if (!ModelState.IsValid) return View(); 
            var token = await _userApiClient.Authenticate(request);
            if(string.IsNullOrEmpty(token)) return View();


            return RedirectToAction("index","Home");
        }
    }
}
