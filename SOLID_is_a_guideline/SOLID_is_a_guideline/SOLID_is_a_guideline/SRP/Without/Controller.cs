using System.Collections.Generic;
using System.Linq;

namespace SOLID_is_a_guideline.SRP.Without
{
	// In this system (our context) all controllers only handle 1 action (action per-controller)
	
	public class Controller
	{
		private readonly IDocumentSession session;

		public Controller(IDocumentSession session)
		{
			this.session = session;
		}

		public PaymentViewModel Get(PaymentsRequest request)
		{
			var payments = GetPayments(request);
			var model = new PaymentViewModel();
			Map(payments, model);

			return model;
		}

		private IQueryable<Payment> GetPayments(PaymentsRequest request)
		{
			return session
				.Query<Payment>()
				.Where(c => c.Price < request.MinPrice)
				.Where(c => c.Price > request.MaxPrice)
				.Take(request.PageSize);
		}

		private void Map(IEnumerable<Payment> payments, PaymentViewModel model)
		{
			var dtos = new List<PaymentDto>();

			foreach (var p in payments)
			{
				var dto = new PaymentDto
					          {
						          Model = p.Model,
						          Manufacturer = p.Manufacturer,
						          Price = p.Price,
						          NumberOfDoors = p.NumberOfDoors
					          };

				dtos.Add(dto);
			}

			model.Payments = dtos;
		}
	}
}