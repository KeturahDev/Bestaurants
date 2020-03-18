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
  }
}