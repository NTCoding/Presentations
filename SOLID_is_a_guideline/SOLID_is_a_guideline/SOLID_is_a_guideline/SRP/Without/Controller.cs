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

		public CarsViewModel Get(CarsRequestModel requestModel)
		{
			var cars = GetCars(requestModel);
			var model = new CarsViewModel();
			Map(cars, model);

			return model;
		}

		private IQueryable<Car> GetCars(CarsRequestModel requestModel)
		{
			return session
				.Query<Car>()
				.Where(c => c.Price < requestModel.MinPrice)
				.Where(c => c.Price > requestModel.MaxPrice)
				.Take(requestModel.PageSize);
		}

		private void Map(IEnumerable<Car> cars, CarsViewModel model)
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