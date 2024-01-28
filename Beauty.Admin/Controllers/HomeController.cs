using Beauty.Admin.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Security.Claims;

namespace Beauty.Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ManageAccount _manageAccount;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(ILogger<HomeController> logger, ManageAccount manageAccount,IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _manageAccount = manageAccount;
            _webHostEnvironment = webHostEnvironment;
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
            return View("~/views/home/profile.cshtml");
        }
        [HttpPost]
        public async Task<IActionResult> Profile([FromForm] Profile profile)
        {
            try
            {
                if (profile != null)
                {
                    var files = HttpContext.Request.Form.Files;

                    if (files.Count > 0)
                    {
                        foreach (var Image in files)
                        {
                            if (Image != null && Image.Length > 0)
                            {
                                var file = Image;
                                var uploads = Path.Combine(_webHostEnvironment.WebRootPath, "Content\\Image\\");
                                if (!Directory.Exists(uploads))
                                {
                                    Directory.CreateDirectory(uploads);
                                }
                                if (file.Length > 0)
                                {
                                    string guid = Guid.NewGuid().ToString("N");
                                    string fixedGuid = guid.Substring(0, 20);
                                    var fileName = fixedGuid + Path.GetExtension(file.FileName);
                                    using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
                                    {
                                        await file.CopyToAsync(fileStream);
                                        profile.Image = fileName;
                                    }
                                }
                            }
                        }

                    }
                   var data = await _manageAccount.Profile(profile);
                    return Ok(data);

                }
                else
                {
                    return Ok(new { Message = "Something went wrong !!!" });

                }

            }
            catch (Exception ex)
            {
                return View("/views/shared/error.cshtml", ex);
            }

        }

        [HttpGet]
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
                 
                    var claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.Name, log.Email,log.Password));
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(principal));

                    var data = await _manageAccount.Login(log);
                    if (data != null)
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
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePassword change)
        {
            try
            {
                var data = await _manageAccount.ChangePassword(change);
                return Ok(new { Message = data });
                
            }
            catch (Exception ex)
            {

                return Ok(new { Message = "Technical Error !!" });
            }
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login", "Home");
        }
    }

}
