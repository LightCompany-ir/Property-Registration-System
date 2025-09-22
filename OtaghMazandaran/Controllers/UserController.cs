using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace OtaghMazandaran.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index() { return View(); }
        public IActionResult EditMe() { return View(); }
        [HttpPost]
        public IActionResult DeleteMyPhoto()
        {
            //int userid = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            //DataLayer.Models.User usr = _usrdb.GetById(userid);

            //if (usr.UserImage != "Default.png")
            //{
            //    System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "admin", usr.UserImage));
            //}
            //usr.UserImage = "Default.png";
            //_usrdb.Update(usr);
            return RedirectToAction("EditMe");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ChangeMyPhoto(IFormFile ImgUp)
        {
            //int userid = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            //DataLayer.Models.User usr = _usrdb.GetById(userid);

            //if (usr.UserImage != "Default.png")
            //{
            //    System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "admin", usr.UserImage));
            //}
            //usr.UserImage = string.Concat(Guid.NewGuid(), Path.GetExtension(ImgUp.FileName));
            //string filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "admin", usr.UserImage);
            //using (var stream = new FileStream(filepath, FileMode.Create))
            //{
            //    ImgUp.CopyTo(stream);
            //}
            //_usrdb.Update(usr);
            return RedirectToAction("EditMe");
        }
    }
}
