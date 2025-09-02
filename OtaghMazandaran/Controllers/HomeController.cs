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

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult LogIn() { return View(); }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult LogIn(LoginViewModel Src)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(Src);
        //    }
        //    if (_usrdb.IsLogin(Src) == false)
        //    {
        //        ModelState.AddModelError("UserName", "ورود ناموفق بود");
        //        return View(Src);
        //    }
        //    User? usr = _usrdb.GetUser(Src);
        //    if (usr == null)
        //    {
        //        ModelState.AddModelError("UserName", "ورود ناموفق بود");
        //        return View(Src);
        //    }
        //    var claims = new List<Claim>()
        //    {
        //        new Claim(ClaimTypes.NameIdentifier, usr.UserId.ToString()),
        //        new Claim(ClaimTypes.Name,usr.FullName)
        //    };
        //    var Identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        //    var Principal = new ClaimsPrincipal(Identity);
        //    var properties = new AuthenticationProperties()
        //    {
        //        IsPersistent = true
        //    };
        //    HttpContext.SignInAsync(Principal, properties).Wait();
        //    return RedirectToAction("Index");
        //}
        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }
        public IActionResult SignUp() { return View(); }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult SignUp(SignUpViewModel Src)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(Src);
        //    }
        //    if (_usrdb.IsUserNameExisted(Src.UserName) != 0)
        //    {
        //        ModelState.AddModelError("UserName", "نام کاربری تکراری است");
        //        return View(Src);
        //    }
        //    if (_usrdb.IsPhoneExisted(Src.Phone) != 0)
        //    {
        //        ModelState.AddModelError("Phone", "شماره همراه تکراری است");
        //        return View(Src);
        //    }
        //    _usrdb.SignUpUser(Src);
        //    return RedirectToAction("LogIn");
        //}
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
