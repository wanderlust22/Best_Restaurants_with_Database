using Microsoft.AspNetCore.Mvc;
using BestRestaurants.Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BestRestaurants.Controllers
{
    public class CuisineController : Controller
    {
        private readonly BestRestaurantsContext _db;

        public CuisineController(BestRestaurantsContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<Cuisine> model = _db.Cuisine.ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Cuisine cuisine)
        {
            _db.Cuisine.Add(cuisine);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {

            List<Restaurant> restaurantsOfCuisine = _db.Restaurant.Where(restaurant => restaurant.CuisineId == id).ToList();
            ViewBag.restaurantsOfCuisine = restaurantsOfCuisine;
            Cuisine theCuisine = _db.Cuisine.FirstOrDefault(cuisine => cuisine.CuisineId == id);
            return View(theCuisine);
        }



    }
    
}