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
    public class PropertyRepository : IPropertyRepository
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Property Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Property> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Property> GetAll(int PlaceId)
        {
            throw new NotImplementedException();
        }

        public int Insert(Property src)
        {
            throw new NotImplementedException();
        }

        public int Insert(CreatePropertyMV src)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Property src)
        {
            throw new NotImplementedException();
        }

        public void Update(UpdatePropertyMV src)
        {
            throw new NotImplementedException();
        }
    }
}
