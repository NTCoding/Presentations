using System.Collections.Generic;
using System.Linq;

namespace SOLID_is_a_guideline.OCP.With.Inheritance
{
	// Now we make all our methods virtual so they can be overriden by future sub classes

	// Now we have 2 classes to think about when thinking of the basket 

	// Distributed logic - more code navigations to piece together tiny amounts of logic
	// that belong together anyway

	// Clients need to remember to use the new sub class and not the old base class

	// TDD, CI, do a much better job than OCP

 public class Basket 
  {
  	protected List<CartItem> items;
  
  	public Basket(List<CartItem> items)
  	{
  		this.items = items;
  	}
  
  	public virtual void Add(CartItem product)   
  	{
  		items.Add(product);
  	}
  
  	public virtual void Delete(CartItem product) 
  	{
  		items.Remove(product);
  	}
  
  	public virtual decimal GetTotal() 
  	{
  		return items.Sum(i => i.Price);
  	}
  }
  
  public class BasketWithDiscount : Basket
  {
    public BasketWithDiscount(List<CartItem> items) : base(items){}
 
    public override decimal GetTotal() 
    {
      var subTotal = items.Sum(i => i.Price);
    
      if (subTotal > 75)
        return Apply5PercentDiscount(subTotal);
      else
        return subTotal;
    }
    
    private decimal Apply5PercentDiscount(decimal subTotal)
    {
      return subTotal* (decimal)0.95;
    }		
  }
}