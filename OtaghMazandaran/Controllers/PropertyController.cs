using DataLayer.DTOs;
using DataLayer.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

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
            var rslt = _db.GetAll();
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind(include: "PropertyName,PropertyBrand,PropertyColor,PropertyDescription,PlaceId")]CreatePropertyMV src)
        {
            src.CreatedByUser = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            if(ModelState.IsValid == false)
            {
                ViewBag.Places = _place.GetAll().Select(u => new SelectListItem
                {
                    Value = u.PlaceId.ToString(),
                    Text = u.PlaceName
                }).ToList() as List<SelectListItem>;

                return View(src);
            }
            _db.Insert(src);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            ViewBag.Places = _place.GetAll().Select(u => new SelectListItem
            {
                Value = u.PlaceId.ToString(),
                Text = u.PlaceName
            }).ToList() as List<SelectListItem>;

            return View(_db.Get(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind(include: "PropertyId,PropertyName,PropertyBrand,PropertyColor,PropertyDescription,PlaceId")]UpdatePropertyMV src)
        {
            src.UpdatedByUser = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (ModelState.IsValid == false)
            {
                ViewBag.Places = _place.GetAll().Select(u => new SelectListItem
                {
                    Value = u.PlaceId.ToString(),
                    Text = u.PlaceName
                }).ToList() as List<SelectListItem>;

                return View(src);
            }
            _db.Update(src);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id) { return View(_db.Get(id)); }
        [HttpPost][ValidateAntiForgeryToken]
        public IActionResult DeleteProperty(int PropertyId)
        {
            _db.Delete(PropertyId, Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier)));
            return RedirectToAction("Index");
        }
    }
}
