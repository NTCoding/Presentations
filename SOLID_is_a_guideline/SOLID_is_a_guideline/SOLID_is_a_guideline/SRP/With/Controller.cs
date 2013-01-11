using System.Collections.Generic;
using System.Linq;

namespace SOLID_is_a_guideline.SRP.With
{
	// this is a system with about 15 - 20 endpoints all doing CRUD
	// did we need to create an interface for every class?

	// Does 3 methods in each controller really have the potential 
	// for "fragile designs that break in unexpected ways"?

	// I say no - simple bit of crud - bang it all in the controller
	// wait until the complexity comes

	// and which "user of the system" determines that mapping logic
	// is a responsibility?

	// Image this increase in complexity applied to the entire codebase
	// a lot of extra time, classes, tests and code navigations for no benefit

	public class Controller
	{
		private readonly IPaymentsRepository paymentsRepository;
		private readonly IPaymentsMapper paymentsMapper;

		public Controller(IPaymentsRepository paymentsRepository, IPaymentsMapper paymentsMapper)
		{
			this.paymentsRepository = paymentsRepository;
			this.paymentsMapper = paymentsMapper;
		}

		public PaymentViewModel Get(PaymentsRequest request)
		{
			var payments = paymentsRepository.GetPayments(request.MinPrice, request.MaxPrice, request.PageSize);
			var model = new PaymentViewModel();
			paymentsMapper.Map(payments, model);

			return model;
		}
	}

	public interface IPaymentsRepository
	{
		IQueryable<Payment> GetPayments(int minPrice, int maxPrice, int pageSize);
	}

	public class PaymentsRepository : IPaymentsRepository
	{
		private readonly IDocumentSession session;

		public PaymentsRepository(IDocumentSession session)
		{
			this.session = session;
		}

		public IQueryable<Payment> GetPayments(int minPrice, int maxPrice, int pageSize)
		{
			return session
				.Query<Payment>()
				.Where(c => c.Price < minPrice)
				.Where(c => c.Price > maxPrice)
				.Take(pageSize);
		}
	}

	public interface IPaymentsMapper
	{
		void Map(IEnumerable<Payment> payments, PaymentViewModel model);
	}

	public class PaymentsMapper : IPaymentsMapper
	{
		public void Map(IEnumerable<Payment> payments, PaymentViewModel model)
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