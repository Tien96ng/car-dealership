using Microsoft.AspNetCore.Mvc;
using Dealership.Models;
using System.Collections.Generic;

namespace Dealership.Controllers
{
    public class CarController : Controller
    {

      [HttpGet("/")]
      public ActionResult Index()
      {
        List<Car> allCars = Car.GetAllCar();
        return View(allCars);
      }

      [HttpPost("/")]
      public ActionResult Search(int min, int max)
      {
        List<Car> priceRange = Car.Search(min, max);
        return View(priceRange);
      }

    }
}