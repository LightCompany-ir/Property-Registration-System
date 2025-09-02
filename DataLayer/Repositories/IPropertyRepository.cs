using DataLayer.DTOs;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public interface IPropertyRepository : IDisposable
    {
        IEnumerable<Property> GetAll();
        /// <summary>
        /// List Of Property for One Place
        /// </summary>
        /// <param name="PlaceId">Place Id</param>
        /// <returns>List Of Property for One Place</returns>
        IEnumerable<Property> GetAll(int PlaceId);
        Property Get(int id);
        int Insert(Property src);
        int Insert(CreatePropertyMV src);
        void Update(Property src);
        void Update(UpdatePropertyMV src);
        /// <summary>
        /// Delete Property if User Finded
        /// </summary>
        /// <param name="id">Property Id</param>
        /// <param name="UserId">Admin User Id</param>
        /// <returns>false if user not found</returns>
        bool Delete(int id, int UserId);
        void Save();
    }
}
