using DataLayer.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace OtaghMazandaran.Controllers
{
    public class PropertyController : Controller
    {
        private IPropertyRepository _db;
        public PropertyController(IPropertyRepository propertyRepository)
        {
            _db = propertyRepository;
        }
        public IActionResult Index(int id = 0)
        {
            if(id == 0) return View(_db.GetAll());
            else return View(_db.GetAll(id));
        }
    }
}
