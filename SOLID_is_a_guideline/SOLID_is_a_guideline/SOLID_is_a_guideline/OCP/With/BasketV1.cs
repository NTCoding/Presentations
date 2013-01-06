namespace SOLID_is_a_guideline.OCP.With
{
	// now we are open for extension
	// and we are closed for modification
	// but look at all the complexity we had to introduce to get there

	// are we in a better place or worse?

	// how many code navigations to understand the logic?
	// how many new abstractions to hold in our head?
	// how many new opportunities to introduce unwanted coupling?
	// how much longer will it take?
	// how many extra tests will there be?

	// imagine this complexity explosion across the entire codebase?

	public class BasketV1
	{
		private readonly IBasketUdder adder;
		private readonly IBasketDeleter deleter;
		private readonly ITotalRetriever totalRetriever;

		public BasketV1(IBasketUdder adder, IBasketDeleter deleter)
		{
			this.adder = adder;
			this.deleter = deleter;
		}

		public void Add(CartItem product)
		{
			adder.Add(product);
		}

		public void Delete(CartItem product)
		{
			deleter.Delete(product);
		}

		public decimal GetTotal()
		{
			return totalRetriever.Retrieve();
		}
	}

	public interface IBasketDeleter
	{
		void Delete(CartItem product);
	}

	public interface IBasketUdder
	{
		void Add(CartItem product);
	}

	class BasketUdder : IBasketUdder
	{
		public void Add(CartItem product)
		{

		}
	}

	public interface ITotalRetriever
	{
		decimal Retrieve();
	}

	class TotalRetriever : ITotalRetriever
	{
		public decimal Retrieve()
		{
			throw new System.NotImplementedException();
		}
	}
}