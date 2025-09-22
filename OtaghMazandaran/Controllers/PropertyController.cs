using DataLayer.DTOs;
using DataLayer.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OtaghMazandaran.Controllers
{
    public class PropertyController : Controller
    {
        private IPropertyRepository _db;
        private IPlaceRepository _place;
        public PropertyController(IPropertyRepository propertyRepository,IPlaceRepository placeRepository)
        {
            _db = propertyRepository;
            _place = placeRepository;
        }
        public IActionResult Index(int id = 0)
        {
            if(id == 0) return View(_db.GetAll());
            else return View(_db.GetAll(id));
        }
        public IActionResult Create()
        {
            ViewBag.Places = _place.GetAll().Select(u => new SelectListItem
            {
                Value = u.PlaceId.ToString(),
                Text = u.PlaceName
            }).ToList() as List<SelectListItem>;

            return View();
        }
        public IActionResult Create([Bind(include: "PropertyName,PropertyBrand,PropertyColor,PropertyDescription,PlaceId")]CreatePropertyMV src)
        {
            return RedirectToAction("Index");
        }
        public IActionResult Edit() { return View(); }
        public IActionResult Delete() { return View(); }
    }
}
