namespace Bestaurant.Models
{
  public class Restaurant
  {
    public int RestaurantId {get;set;}
    public string Name {get;set;}
    public int CuisineId {get;set;}
    public string Description {get;set;}
    public string Address {get;set;}
    // public bool Delivery {get;set;} //translate to 1/0 at some point
  }
}