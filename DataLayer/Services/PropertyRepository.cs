using DataLayer.Context;
using DataLayer.DTOs;
using DataLayer.Models;
using DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Services
{
    public class PropertyRepository : IPropertyRepository
    {
        private MyContext _db;
        public PropertyRepository(MyContext context)
        {
            _db = context;
        }
        public IEnumerable<DataLayer.Models.Property> GetAll()
        {
            return _db.Properties.Where(w => w.DeletedByUser == null).OrderByDescending(o => o.UpdatedDate).Include(u => u.Place);
        }
        public IEnumerable<DataLayer.Models.Property> GetAll(int PlaceId)
        {
            return _db.Properties.Where(u => u.PlaceId == PlaceId && u.DeletedByUser == null)
                .OrderByDescending(o => o.UpdatedDate).Include(u => u.Place);
        }
        public DataLayer.Models.Property Get(int id)
        {
            return _db.Properties.First(u => u.PropertyId == id);
        }
        public int Insert(DataLayer.Models.Property src)
        {
            _db.Add(src);
            Save();
            return src.PropertyId;
        }
        public int Insert(CreatePropertyMV src)
        {
            Place? place = _db.Places.FirstOrDefault(u => u.PlaceId == src.PlaceId);
            if (place == null) throw new KeyNotFoundException();
            DataLayer.Models.Property rslt = new DataLayer.Models.Property()
            {
                PropertyName = src.PropertyName,
                OldPropertyNumber = src.OldPropertyNumber,
                NewPropertyNumber = src.NewPropertyNumber,
                PropertyDescription = src.PropertyDescription,
                PlaceId = src.PlaceId,
                CreatedByUser = src.CreatedByUser,
                UpdatedByUser = null,
                DeletedByUser = null,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };
            _db.Add(rslt);
            Save();
            return rslt.PropertyId;
        }
        public void Update(DataLayer.Models.Property src)
        {
            src.UpdatedDate = DateTime.Now;
            _db.Update(src);
            Save();
        }
        public void Update(UpdatePropertyMV src)
        {
            DataLayer.Models.Property rslt = _db.Properties.First(u => u.PropertyId == src.PropertyId);

            rslt.PropertyId = src.PropertyId;
            rslt.PropertyName = src.PropertyName;
            rslt.OldPropertyNumber = src.OldPropertyNumber;
            rslt.NewPropertyNumber = src.NewPropertyNumber;
            rslt.PropertyDescription = src.PropertyDescription;
            rslt.PlaceId = src.PlaceId;
            rslt.UpdatedByUser = src.UpdatedByUser;
            rslt.DeletedByUser = null;
            rslt.UpdatedDate = DateTime.Now;

            Update(rslt);
        }
        public bool Delete(int id, int UserId)
        {
            if (_db.Users.Any(u => u.AdminUserId == UserId) == false) return false;
            DataLayer.Models.Property src = Get(id);
            src.DeletedByUser = UserId;
            Update(src);
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

        public UpdatePropertyMV GetforUpdateMV(int id)
        {
            Models.Property src = Get(id);
            UpdatePropertyMV rslt = new UpdatePropertyMV()
            {
                PropertyId = src.PropertyId,
                PropertyName = src.PropertyName,
                OldPropertyNumber = src.OldPropertyNumber,
                NewPropertyNumber = src.NewPropertyNumber,
                PropertyDescription = src.PropertyDescription,
                PlaceId = src.PlaceId,
                UpdatedByUser = 0
            };
            return rslt;
        }
    }
}
