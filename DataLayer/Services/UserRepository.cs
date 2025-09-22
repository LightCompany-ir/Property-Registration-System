using DataLayer.Context;
using DataLayer.DTOs;
using DataLayer.Models;
using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Services
{
    public class UserRepository : IUserRepository
    {
        private MyContext _db;
        public UserRepository(MyContext context)
        {
            _db = context;
        }
        public void ActiveUser(int Id)
        {
            AdminUser src = _db.Users.First(u=>u.AdminUserId == Id);
            src.IsActive = true;
            _db.Update(src);
            Save();
        }

        public bool CanDelete(int id)
        {
            if (_db.Properties.Any(u => u.CreatedByUser == id || u.UpdatedByUser == id))
                return false;
            else return true;
        }

        public bool Delete(int id)
        {
            if(_db.Properties.Any(u => u.CreatedByUser == id || u.UpdatedByUser == id))
                return false;
            AdminUser src = _db.Users.First(u => u.AdminUserId == id);
            _db.Users.Remove(src);
            Save();
            return true;
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public AdminUser Get(int id)
        {
            return _db.Users.First(u => u.AdminUserId == id);
        }

        public IEnumerable<AdminUser> GetAll()
        {
            return _db.Users;
        }

        public IEnumerable<AdminUser> GetNotActive()
        {
            return _db.Users.Where(u=>u.IsActive == false);
        }

        public AdminUser? GetUser(UserLogin Src)
        {
            return _db.Users.FirstOrDefault(u => u.UserName == Src.UserName && u.Password == Src.Password);
        }

        public int Insert(AdminUser src)
        {
            _db.Users.Add(src);
            Save();
            return src.AdminUserId;
        }

        public bool IsLogin(UserLogin Src)
        {
            return _db.Users.Any(u => u.IsActive && u.UserName == Src.UserName && u.Password == Src.Password);
        }

        public int IsPhoneExisted(string phone)
        {
            AdminUser? src = _db.Users.FirstOrDefault(u => u.Phone == phone);
            if (src == null) return 0;
            else return src.AdminUserId;
        }

        public int IsUserNameExisted(string UserName)
        {
            AdminUser? src = _db.Users.FirstOrDefault(u => u.UserName == UserName);
            if (src == null) return 0;
            else return src.AdminUserId;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public int SignUpUser(UserSignUp Src)
        {
            AdminUser admin = new AdminUser()
            {
                FullName = Src.FullName,
                UserName = Src.UserName.ToLower(),
                Password = Src.Password,
                Phone = Src.Phone,
                RegisterDate = DateTime.Now,
                UserImage = "Default.png",
                IsActive = false
            };
            _db.Add(admin);
            Save();
            return admin.AdminUserId;
        }

        public void Update(AdminUser src)
        {
            _db.Update(src);
            Save();
        }
    }
}
