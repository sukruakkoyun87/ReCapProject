using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.Constant;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }


        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<List<Car>>(Messages.Maintenance);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarListed);
        }

        public IResult Add(Car car)
        {

            if (car.CarName.Min()==2)
            {
                return new ErrorResult(Messages.CarInvalid);
            }
            else if (car.DailyPrice>0)
            {
              return new ErrorResult(Messages.CarDailyPriceZero);
            }
            else
            {
              _carDal.Add(car);
              return new SuccessResult( Messages.CarAdded);
            }
           
        }

        public IResult Update(Car car)
        {
            if (car.CarName.Min() == 2)
            {
                return new ErrorResult(Messages.CarInvalid);
            }
            else if (car.DailyPrice > 0)
            {
                return new ErrorResult(Messages.CarDailyPriceZero);
            }
            else
            {
                _carDal.Update(car);
                return new SuccessResult(Messages.CarUpdated);
            }

        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(x => x.Id == id));
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(x => x.BrandId == brandId));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(x => x.ColorId == colorId));
        }

        public IDataResult<List<CarDetailDto>>GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

    
    }
}
