using System.Collections.Generic;
using System.Linq;

namespace SOLID_is_a_guideline.OCP.Without
{
	// in a period of 12 months the business updated the basket...
	// a tiny change that had no potential for: "a cascade of changes to dependent modules"

	// we optimised for no reason
	// the business requirements were low risk - we have TDD anyway

	// we had to modify our class directly (violating OCP) - but what's our problem here?

	public class BasketV2
	{
		private List<CartItem> items;

		public BasketV2(List<CartItem> items)
		{
			this.items = items;
		}

		public void Add(CartItem product)   
		{
			items.Add(product);
		}

		public void Delete(CartItem product) 
		{
			items.Remove(product);
		}

		// The business wanted a simple discount policy 
		public decimal GetTotal() 
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