using Beauty.Admin.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Beauty.Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ManageAccount _manageAccount;

        public HomeController(ILogger<HomeController> logger, ManageAccount manageAccount)
        {
            _logger = logger;
            _manageAccount = manageAccount;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Profile()
        {
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View("/views/home/login.cshtml");
        }
        [HttpPost]
        public async Task<IActionResult> Login(Login log)
        {
            try
            {
                if (log != null)
                {
                    var data = await _manageAccount.Login(log);
                    if(data != null)
                    {
                        return Ok(new { Message = data });
                    }
                    else
                    {
                        return Ok(new { Message = "Invaild Password !!" });
                    }
                }
                else
                {
                    return Ok(new { Message = "Something went wrong !!!" });
                }
            }
            catch (Exception ex)
            {
                return Ok(new { Message = "Technical Error !!" });
            }
        }
        public async Task<IActionResult> Logout()
        {
            //await HttpContext.SignOutAsync();

            // Optionally, perform any additional cleanup or redirect to another page
            return RedirectToAction("Login", "Home");
        }
    }

}
