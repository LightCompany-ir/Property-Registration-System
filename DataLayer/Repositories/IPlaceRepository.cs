using DataLayer.DTOs;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public interface IPlaceRepository:IDisposable
    {
        IEnumerable<Place> GetAll();
        Place Get(int id);
        int Insert(Place src);
        void Update(Place src);
        /// <summary>
        /// Delete A Place
        /// </summary>
        /// <param name="id"> Place Id</param>
        /// <returns>False if Place Has Property</returns>
        bool Delete(int id);
        void Save();
    }
}
