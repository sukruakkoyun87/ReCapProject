using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;



namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RecapDataContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (RecapDataContext context = new RecapDataContext())
            {
                var result = from r in context.Rentals
                             join c in context.Customers
                             on r.CustomerId equals c.Id
                             join u in context.Users
                             on c.UserId equals u.Id
                             join car in context.Cars
                             on r.CarId equals car.Id
                             join b in context.Brands
                             on car.BrandId equals b.Id
                             select new RentalDetailDto
                             {
                                 CompanyName = c.CompanyName,
                                 RentDate=r.RentDate,
                                 ReturnDate=r.ReturnDate,
                                 UserName=u.FirstName +" "+u.LastName,
                                 CarName=b.BrandName+" "+car.CarName,
                                 DailyPrice=car.DailyPrice,
                                 Id=r.Id
                                 
                             };



                return result.ToList() ;
             }
        }
    }
}
