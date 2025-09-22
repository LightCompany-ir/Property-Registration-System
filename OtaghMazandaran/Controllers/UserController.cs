using DataLayer.Models;
using DataLayer.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace OtaghMazandaran.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        IUserRepository _db;
        public UserController(IUserRepository userRepository)
        {
            _db = userRepository;
        }
        public IActionResult Index() { return View(_db.GetAll()); }
        #region Edit My Profile
        public IActionResult EditMe()
        {
            int userid = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            DataLayer.Models.AdminUser usr = _db.Get(userid);
            return View(usr);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditMe([Bind(include: "FullName,Phone,UserName,Password,IsActive")] AdminUser Src)
        {
            ModelState.Remove("Password");
            if (!ModelState.IsValid)
            {
                return View(Src);
            }

            int userid = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            DataLayer.Models.AdminUser usr = _db.Get(userid);

            if (usr.Phone != Src.Phone)
            {
                int phonexisted = _db.IsPhoneExisted(Src.Phone);
                if (phonexisted != 0 && phonexisted != usr.AdminUserId)
                {
                    ModelState.AddModelError("Phone", "این شماره همراه برای کاربر دیگری ثبت شده");
                }
                else usr.Phone = Src.Phone;
            }

            if (usr.UserName != Src.UserName)
            {
                int usrnamexisted = _db.IsUserNameExisted(Src.UserName);
                if (usrnamexisted != 0 && usrnamexisted != usr.AdminUserId)
                {
                    ModelState.AddModelError("UserName", "این نام کاربری برای کاربر دیگری ثبت شده");
                }
                else usr.UserName = Src.UserName;
            }

            if (string.IsNullOrEmpty(Src.Password) == false)
            {
                usr.Password = Src.Password;
            }

            usr.FullName = Src.FullName;
            usr.IsActive = Src.IsActive;

            _db.Update(usr);
            return View(usr);
        }

        [HttpPost]
        public IActionResult DeleteMyPhoto()
        {
            int userid = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            DataLayer.Models.AdminUser usr = _db.Get(userid);

            if (usr.UserImage != "Default.png")
            {
                System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "admin", usr.UserImage));
            }
            usr.UserImage = "Default.png";
            _db.Update(usr);
            return RedirectToAction("EditMe");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ChangeMyPhoto(IFormFile ImgUp)
        {
            int userid = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            DataLayer.Models.AdminUser usr = _db.Get(userid);

            if (usr.UserImage != "Default.png")
            {
                System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "admin", usr.UserImage));
            }
            usr.UserImage = string.Concat(Guid.NewGuid(), Path.GetExtension(ImgUp.FileName));
            string filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "admin", usr.UserImage);
            using (var stream = new FileStream(filepath, FileMode.Create))
            {
                ImgUp.CopyTo(stream);
            }
            _db.Update(usr);
            return RedirectToAction("EditMe");
        }
        #endregion
        public IActionResult ActiveUser(int id)
        {
            _db.ActiveUser(id);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id) { return View(_db.Get(id)); }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind(include: "AdminUserId,FullName,UserName,Password,Phone,IsActive")] AdminUser src)
        {
            ModelState.Remove("Password");
            if (!ModelState.IsValid)
            {
                return View(src);
            }
            AdminUser rslt = _db.Get(src.AdminUserId);
            rslt.FullName = src.FullName;
            if (rslt.UserName != src.UserName)
            {
                int usrnamexisted = _db.IsUserNameExisted(src.UserName);
                if (usrnamexisted != 0 && usrnamexisted != rslt.AdminUserId)
                {
                    ModelState.AddModelError("UserName", "این نام کاربری برای کاربر دیگری ثبت شده");
                }
                else rslt.UserName = src.UserName;
            }
            if (string.IsNullOrEmpty(src.Password) == false)
            {
                rslt.Password = src.Password;
            }
            if (rslt.Phone != src.Phone)
            {
                int phonexisted = _db.IsPhoneExisted(src.Phone);
                if (phonexisted != 0 && phonexisted != rslt.AdminUserId)
                {
                    ModelState.AddModelError("Phone", "این شماره همراه برای کاربر دیگری ثبت شده");
                }
                else rslt.Phone = src.Phone;
            }
            rslt.IsActive = src.IsActive;
            _db.Update(rslt);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id) { return View(_db.Get(id)); }
    }
}
