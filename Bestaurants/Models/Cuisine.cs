using System.Collections.Generic;

namespace Bestaurant.Models
{
  public class Cuisine 
  {
    public string Name {get;set;}
    public int CuisineId {get;set;}
    public virtual ICollection<Restaurant> Restaurants {get;set;}
  }
}