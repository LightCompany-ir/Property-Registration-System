using DataLayer.DTOs;
using DataLayer.Models;
using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Services
{
    public class UserRepository : IUserRepository
    {
        public void ActiveUser(int Id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public AdminUser Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AdminUser> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AdminUser> GetNotActive()
        {
            throw new NotImplementedException();
        }

        public AdminUser? GetUser(UserLogin Src)
        {
            throw new NotImplementedException();
        }

        public int Insert(AdminUser src)
        {
            throw new NotImplementedException();
        }

        public bool IsLogin(UserLogin Src)
        {
            throw new NotImplementedException();
        }

        public int IsPhoneExisted(string phone)
        {
            throw new NotImplementedException();
        }

        public int IsUserNameExisted(string UserName)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public int SignUpUser(UserSignUp Src)
        {
            throw new NotImplementedException();
        }

        public void Update(AdminUser src)
        {
            throw new NotImplementedException();
        }
    }
}
