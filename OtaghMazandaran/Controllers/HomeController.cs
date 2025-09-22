using DataLayer.DTOs;
using DataLayer.Models;
using DataLayer.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OtaghMazandaran.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace OtaghMazandaran.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IUserRepository _user;

        public HomeController(ILogger<HomeController> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _user = userRepository;
        }
        [Authorize]
        public IActionResult Index()
        {
            //Welcome Page
            return View();
        }
        public IActionResult LogIn() { return View(); }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LogIn(UserLogin Src)
        {
            if (!ModelState.IsValid)
            {
                return View(Src);
            }
            if (_user.IsLogin(Src) == false)
            {
                ModelState.AddModelError("UserName", "ورود ناموفق بود");
                return View(Src);
            }
            AdminUser? usr = _user.GetUser(Src);
            if (usr == null)
            {
                ModelState.AddModelError("UserName", "ورود ناموفق بود");
                return View(Src);
            }
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, usr.AdminUserId.ToString()),
                new Claim(ClaimTypes.Name,usr.FullName)
            };
            var Identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var Principal = new ClaimsPrincipal(Identity);
            var properties = new AuthenticationProperties()
            {
                IsPersistent = true
            };
            HttpContext.SignInAsync(Principal, properties).Wait();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }
        public IActionResult SignUp() { return View(); }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SignUp(UserSignUp Src)
        {
            if (!ModelState.IsValid)
            {
                return View(Src);
            }
            if (_user.IsUserNameExisted(Src.UserName) != 0)
            {
                ModelState.AddModelError("UserName", "نام کاربری تکراری است");
                return View(Src);
            }
            if (_user.IsPhoneExisted(Src.Phone) != 0)
            {
                ModelState.AddModelError("Phone", "شماره همراه تکراری است");
                return View(Src);
            }
            _user.SignUpUser(Src);
            return RedirectToAction("LogIn");
        }
        public IActionResult ForgotPassword()
        {
            throw new NotImplementedException();
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
    }
}
