using Microsoft.AspNetCore.Mvc;
using Bestaurant.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Bestaurant.Controllers
{
  public class CuisineController : Controller 
  {
    private readonly BestaurantContext _db;

    public CuisineController(BestaurantContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Cuisine> model = _db.Cuisines.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Cuisine cuisine)
    {
      _db.Cuisines.Add(cuisine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Cuisine currentCuisine = _db.Cuisines.FirstOrDefault(cuisine => cuisine.CuisineId == id);
      currentCuisine.Restaurants = _db.Restaurants.Where(restaurant => restaurant.CuisineId == id).ToList();
      return View(currentCuisine);
    }

    public ActionResult Edit(int id)
    {
      Cuisine thisCuisine = _db.Cuisines.FirstOrDefault(cuisine => cuisine.CuisineId == id);
      return View(thisCuisine);
    }

    [HttpPost]
    public ActionResult Edit(Cuisine cuisine)
    {
      _db.Entry(cuisine).State = EntityState.Modified; //find and update all the entries for the properties of this specific instance
      //state (state of instance), is now equal to MODIFIED state..
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}