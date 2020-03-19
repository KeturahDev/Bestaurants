using Microsoft.AspNetCore.Mvc;
using Bestaurant.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Bestaurant.Controllers
{
  public class RestaurantController : Controller
  {
    private readonly BestaurantContext _db;

    public RestaurantController(BestaurantContext db)
    {
      _db = db;
    }

    public ActionResult Create()
    {
      ViewBag.CuisineId = new SelectList(_db.Cuisines, "CuisineId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Restaurant restaurant)
    {
      _db.Restaurants.Add(restaurant);
      _db.SaveChanges();      
      // int id = restaurant.CuisineId;
      return RedirectToAction("Index", "Cuisine"); /////
      // return RedirectToAction("Details", "Cuisine", id);
    }

    public ActionResult Details(int id)
    {
      Restaurant currentRestaurant = _db.Restaurants.FirstOrDefault(restaurant => restaurant.RestaurantId == id);
      return View(currentRestaurant);
    }

    public ActionResult Edit(int id)
    {
      Restaurant currentRestaurant = _db.Restaurants.FirstOrDefault(restaurant => restaurant.RestaurantId == id);
      return View(currentRestaurant);
    }

    [HttpPost]
    public ActionResult Edit(Restaurant restaurant)
    {
      _db.Entry(restaurant).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = restaurant.RestaurantId });
    }

    public ActionResult Delete(int id)
    {
      Restaurant currentRestaurant = _db.Restaurants.FirstOrDefault(model => model.RestaurantId == id);
      return View(currentRestaurant);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult ConfirmDelete(int id)
    {
      Restaurant currentRestaurant = _db.Restaurants.FirstOrDefault(restaurant => restaurant.RestaurantId == id);
      _db.Restaurants.Remove(currentRestaurant);
      _db.SaveChanges();
      return RedirectToAction("Details", "Cuisine", new {id = currentRestaurant.CuisineId});
    }
  }
}