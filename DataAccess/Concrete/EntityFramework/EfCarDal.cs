using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RecapDataContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RecapDataContext context = new RecapDataContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                                 on c.BrandId equals b.Id
                             join col in context.Colors
                                 on c.ColorId equals col.Id
                             select new CarDetailDto
                             {
                                 Id = c.Id,
                                 BrandName = b.BrandName,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 ModelYear = c.ModelYear,
                                 ColorName = col.ColorName,
                                 CarName = c.CarName
                             };
                return result.ToList();
            }
        }
    }
}
