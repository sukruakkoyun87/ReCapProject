﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.Constant;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class BrandManager:IBrandService
    {
        private IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }


        public IDataResult<List<Brand>> GetAll()
        {
            if (DateTime.Now.Hour==23)
            {
                return new ErrorDataResult<List<Brand>>(Messages.Maintenance);
            }
            else
            {
                return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(),Messages.BrandListed);
            }
            
        }
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
          
          _brandDal.Add(brand);
           return new SuccessResult(Messages.BrandAdded);
        }

        public IResult Update(Brand brand)
        {
            if (brand.BrandName.Min() == 2)
            {
                return new ErrorResult(Messages.BrandInvalid);
            }
            else
            {
                _brandDal.Update(brand);
                return new SuccessResult(Messages.BrandAdded);
            }

        }

        public IResult Delete(Brand brand)
        {
           _brandDal.Delete(brand);
           return new SuccessResult(Messages.BrandDeleted);
        }

        public IDataResult<Brand> GetById(int id)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(x => x.Id == id));
        }
    }
}
