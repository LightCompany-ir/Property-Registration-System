using Microsoft.AspNetCore.Mvc;

namespace OtaghMazandaran.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
