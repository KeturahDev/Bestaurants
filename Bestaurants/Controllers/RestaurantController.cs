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

    public ActionResult Create(int id)
    {
      try
      {
        Cuisine thisCuisine = _db.Cuisines.FirstOrDefault(cuisine => cuisine.CuisineId == id);
        ViewBag.Cuisine = thisCuisine;
        return View();
      }
      catch
      {
        return RedirectToAction("Index", "Controller");
      }
    }

    [HttpPost]
    public ActionResult Create(Restaurant restaurant)
    {
      try
      {
        _db.Restaurants.Add(restaurant);
        _db.SaveChanges();      
        return RedirectToAction("Details", "Cuisine", new {id = restaurant.CuisineId});
      }
      catch
      {
        return RedirectToAction("Index", "Cuisine");
      }
    }

    public ActionResult Details(int id)
    {
      try
      {
        Restaurant currentRestaurant = _db.Restaurants.FirstOrDefault(restaurant => restaurant.RestaurantId == id);
        return View(currentRestaurant);
      }
      catch
      {
        return RedirectToAction("Index", "Cuisine");
      }
    }

    public ActionResult Edit(int id)
    {
      try
      {
        Restaurant currentRestaurant = _db.Restaurants.FirstOrDefault(restaurant => restaurant.RestaurantId == id);
        return View(currentRestaurant);
      }
      catch
      {
        return RedirectToAction("Index", "Cuisine");
      }
    }

    [HttpPost]
    public ActionResult Edit(Restaurant restaurant)
    {
      try
      {  
        _db.Entry(restaurant).State = EntityState.Modified;
        _db.SaveChanges();
        return RedirectToAction("Details", new { id = restaurant.RestaurantId });
      }
      catch
      {
        return RedirectToAction("Index", "Cuisine");
      }
    }

    public ActionResult Delete(int id)
    {
      try
      {
        Restaurant currentRestaurant = _db.Restaurants.FirstOrDefault(model => model.RestaurantId == id);
        return View(currentRestaurant);
      }
      catch
      {
        return RedirectToAction("Index", "Cuisine");
      }
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult ConfirmDelete(int id)
    {
      try
      {
        Restaurant currentRestaurant = _db.Restaurants.FirstOrDefault(restaurant => restaurant.RestaurantId == id);
        _db.Restaurants.Remove(currentRestaurant);
        _db.SaveChanges();
        return RedirectToAction("Details", "Cuisine", new {id = currentRestaurant.CuisineId});
      }
      catch
      {
        return RedirectToAction("Index", "Cuisine");
      }
    }
  }
}