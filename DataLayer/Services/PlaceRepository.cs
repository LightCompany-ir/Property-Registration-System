using DataLayer.Context;
using DataLayer.DTOs;
using DataLayer.Models;
using DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Services
{
    public class PlaceRepository : IPlaceRepository
    {
        private MyContext _db;
        public PlaceRepository(MyContext myContext)
        {
            _db = myContext;
        }
        public IEnumerable<Place> GetAll()
        {
            return _db.Places;
        }
        public Place Get(int id)
        {
            return _db.Places.Include(t => t.Properties).First(u => u.PlaceId == id);
        }
        public int Insert(Place src)
        {
            _db.Places.Add(src);
            Save();
            return src.PlaceId;
        }
        public void Update(Place src)
        {
            _db.Update(src);
            Save();
        }
        /// <summary>
        /// Delete A Place
        /// </summary>
        /// <param name="id"> Place Id</param>
        /// <returns>False if Place Has Property</returns>
        public bool Delete(int id)
        {
            if (_db.Properties.Any(p => p.PlaceId == id) == true) return false;
            _db.Places.Remove(Get(id));
            Save();
            return true;
        }
        public void Save()
        {
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db?.Dispose();
        }
    }
}
