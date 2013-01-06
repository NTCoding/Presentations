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
		private readonly ICarsRepository carsRepository;
		private readonly ICarsMapper carsMapper;

		public Controller(ICarsRepository carsRepository, ICarsMapper carsMapper)
		{
			this.carsRepository = carsRepository;
			this.carsMapper = carsMapper;
		}

		public CarsViewModel Get(CarsRequestModel requestModel)
		{
			var cars = carsRepository.GetCars(requestModel.MinPrice, requestModel.MaxPrice, requestModel.PageSize);
			var model = new CarsViewModel();
			carsMapper.Map(cars, model);

			return model;
		}
	}

	public interface ICarsRepository
	{
		IQueryable<Car> GetCars(int minPrice, int maxPrice, int pageSize);
	}

	public class CarsRepository : ICarsRepository
	{
		private readonly IDocumentSession session;

		public CarsRepository(IDocumentSession session)
		{
			this.session = session;
		}

		public IQueryable<Car> GetCars(int minPrice, int maxPrice, int pageSize)
		{
			return session
				.Query<Car>()
				.Where(c => c.Price < minPrice)
				.Where(c => c.Price > maxPrice)
				.Take(pageSize);
		}
	}

	public interface ICarsMapper
	{
		void Map(IEnumerable<Car> cars, CarsViewModel model);
	}

	public class CarsMapper : ICarsMapper
	{
		public void Map(IEnumerable<Car> cars, CarsViewModel model)
		{
			var carDtos = new List<ShowCarDto>();

			foreach (var car in cars)
			{
				var dto = new ShowCarDto
				{
					Model = car.Model,
					Manufacturer = car.Manufacturer,
					Price = car.Price,
					NumberOfDoors = car.NumberOfDoors
				};

				carDtos.Add(dto);
			}

			model.Cars = carDtos;
		}
	}
}