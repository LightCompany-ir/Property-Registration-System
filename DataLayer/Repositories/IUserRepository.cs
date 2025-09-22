using DataLayer.DTOs;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public interface IUserRepository : IDisposable
    {
        IEnumerable<AdminUser> GetAll();
        AdminUser Get(int id);
        int Insert(AdminUser src);
        void Update(AdminUser src);
        /// <summary>
        /// Delete User If has no Property Create Or Update
        /// </summary>
        /// <param name="id">UserId</param>
        /// <returns>false if has any Property</returns>
        bool Delete(int id);
        bool CanDelete(int id);

        IEnumerable<AdminUser> GetNotActive();
        AdminUser? GetUser(UserLogin Src);
        /// <summary>
        /// If Phone Number Assign To Any User return UserId Or Zero if Not find any user
        /// </summary>
        /// <param name="phone">Phone Number As String Start With 09</param>
        /// <returns>User Id Or 0 if Not Find</returns>
        int IsPhoneExisted(string phone);
        /// <summary>
        /// If UserName Assign To Any User return UserId Or Zero if Not find any user
        /// </summary>
        /// <param name="UserName">User Name All To Lower</param>
        /// <returns>User Id Or 0 if Not Find</returns>
        int IsUserNameExisted(string UserName);
        bool IsLogin(UserLogin Src);
        int SignUpUser(UserSignUp Src);
        void ActiveUser(int Id);
        void Save();
    }
}
