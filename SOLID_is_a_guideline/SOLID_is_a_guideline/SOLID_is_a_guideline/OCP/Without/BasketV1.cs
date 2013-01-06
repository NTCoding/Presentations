using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_is_a_guideline.OCP.Without
{
	public class BasketV1
	{
		private List<CartItem> items;

		public BasketV1(List<CartItem> items)
		{
			this.items = items;
		}

		public void Add(CartItem product)   // what if we add new logic to adding a product? e.g. can't add x of some item
		{
			items.Add(product);
		}

		public void Delete(CartItem product) // what if we add new logic for deleting a product? 
		{
			items.Remove(product);
		}

		public decimal GetTotal() // what if the business want to apply a discount policy? e.g. want to apply a discount
		{
			return items.Sum(i => i.Price);
		}
	}
}
