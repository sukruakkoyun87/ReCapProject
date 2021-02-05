using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }


        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public void Add(Car car)
        {

            if (car.CarName.Min()!=2)
            {
                Console.WriteLine("Araba Adı en az iki karakterden oluşmalıdır");
            }
            else if (car.DailyPrice>0)
            {
                Console.WriteLine("Günlük Fiyat sıfırdan büyük olmalıdır");
            }
            else
            {
              _carDal.Add(car);  
            }
           
        }

        public void Update(Car car)
        {
            if (car.CarName.Length >= 2 && car.DailyPrice > 0)
            {
                _carDal.Update(car);

            }
            else
            {
                Console.WriteLine("Araba Adı en az iki karakterden oluşmalıdır");
                Console.WriteLine("Günlük Fiyat sıfırdan büyük olmalıdır");
            }
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public Car GetById(int id)
        {
            return _carDal.Get(x => x.Id == id);
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _carDal.GetAll(x => x.BrandId == brandId);
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _carDal.GetAll(x => x.ColorId == colorId);
        }
    }
}
