using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        private List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car { Id = 1, BrandId = 1, ColorId = 1, DailyPrice = 20000, ModelYear = 2000, Description = "Hatchback"},
                new Car { Id = 2, BrandId = 2, ColorId = 3, DailyPrice = 30000, ModelYear = 2011, Description = "Sport"},
                new Car { Id = 3, BrandId = 3, ColorId = 1,  DailyPrice = 49000,ModelYear = 2015, Description = "Arazi"},
                new Car { Id = 4, BrandId = 1, ColorId = 1,  DailyPrice = 65000,ModelYear = 2020, Description = "Sedan"},

            };
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Update(Car car)
        {
            Car carToUPdate = _cars.SingleOrDefault(x => x.Id == car.Id);
            carToUPdate.BrandId = car.BrandId;
            carToUPdate.ColorId = car.ColorId;
            carToUPdate.DailyPrice = car.DailyPrice;
            carToUPdate.Description = car.Description;
            carToUPdate.ModelYear = car.ModelYear;



        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(x => x.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetById(int carId)
        {
            return _cars.Where(x => x.Id == carId).ToList();
        }
    }
}
