namespace SOLID_is_a_guideline
{
	public class PaymentsRequestModel
	{
		public int MinPrice { get; set; }

		public int MaxPrice { get; set; }

		public int PageSize { get; set; }
	}
}