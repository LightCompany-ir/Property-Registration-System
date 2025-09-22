using DataLayer.Context;
using DataLayer.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace OtaghMazandaran.Controllers
{
    public class PlaceController : Controller
    {
        private IPlaceRepository _db;
        public PlaceController(IPlaceRepository placeRepository)
        {
            _db = placeRepository;
        }
        public IActionResult Index()
        {
            return View(_db.GetAll());
        }
        public IActionResult Create() { return View(); }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind(include: "PlaceName,PlaceDescription")] DataLayer.Models.Place src)
        {
            if(ModelState.IsValid == false)
            {
                return View(src);
            }
            _db.Insert(src);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id) { return View(_db.Get(id)); }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind(include: "PlaceId,PlaceName,PlaceDescription")] DataLayer.Models.Place src)
        {
            if (ModelState.IsValid == false)
            {
                return View(src);
            }
            _db.Update(src);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id) 
        {
            ViewBag.CanDelete = _db.CanDelete(id);
            return View(_db.Get(id)); 
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePlace(int PlaceId)
        {
            _db.Delete(PlaceId);
            return RedirectToAction("Index");
        }
    }
}
