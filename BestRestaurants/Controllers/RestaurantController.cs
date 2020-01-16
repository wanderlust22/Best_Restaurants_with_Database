using Microsoft.AspNetCore.Mvc;
using BestRestaurants.Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BestRestaurants.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly BestRestaurantsContext _db;

        public RestaurantController(BestRestaurantsContext db)
        {
            _db = db;
        }

        public ActionResult Create()
        {
            return View();
        }
        

    }
    
}