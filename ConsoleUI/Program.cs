using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarDetials();

            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            UserManager userManager = new UserManager(new EfUserDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            // userManager.Add(new User { FirstName = "Ali", LastName = "Yılmaz", Email = "Mail@mail.com", Password = "123456" });
            //customerManager.Add(new Customer { UserId = 2, CompanyName = "Yılmaz Ltd. Şti" });


            //rentalManager.Add(new Rental { CustomerId = 1, CarId = 1, RentDate = new DateTime(2021, 02, 10) });

            var rentalAddResult= rentalManager.Add(new Rental { CustomerId = 2, CarId = 1, RentDate = new DateTime(2021, 02, 10) });
            if (rentalAddResult.Success)
            {
                Console.WriteLine(rentalAddResult.Message);
                
            }
            else
            {
                Console.WriteLine(rentalAddResult.Message);
            }
            


            //Console.WriteLine("----- Kiralanan Araç Bilgileri  ----- \n");

            //var rentaldetailResult = rentalManager.GetRentalDetails();

            //if (rentaldetailResult.Success)
            //{
            //    foreach (var detail in rentaldetailResult.Data)
            //    {
            //        Console.WriteLine("Müşteri Adı : {0} --  Şirket Adı : {1} -- Kiralanan Araç Adı : {2} -- Kiralama Başlangıç Tarihi {3} -- Kiralama Bitiş Tarihi : {4} -- Günlük Kirası {5} ",detail.UserName,detail.CompanyName,detail.CarName,detail.RentDate,detail.ReturnDate, string.Format("{0:N2}", detail.DailyPrice));
            //    }
            //}

        }

        private static void CarDetials()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());


            Console.WriteLine("----- Araba Tam Liste ----- \n");

            var detailResult = carManager.GetCarDetails();
            if (detailResult.Success)
            {
                foreach (var detail in detailResult.Data)
                {
                    Console.WriteLine("Id : {0} --- Markası : {1}  --- Araç Adı : {2} --- Rengi : {3} --- Model Yılı : {4} --- Günlük Fiyatı : {5} --- Açıklaması : {6}  ", detail.Id, detail.BrandName, detail.CarName, detail.ColorName, detail.ModelYear, string.Format("{0:N2}", detail.DailyPrice), detail.Description);
                }
            }


            Console.WriteLine("\n----- Araba Markaları ----- \n");


            var brandResult = brandManager.GetAll();

            if (brandResult.Success)
            {
                foreach (var brand in brandResult.Data)
                {
                    Console.WriteLine(" Araç Markaları : {0}", brand.BrandName);
                }
            }



            Console.WriteLine("\n----- Araba Özellikleri ve Fiyatı -----\n");

            var carResult = carManager.GetAll();

            if (carResult.Success)
            {
                foreach (var car in carResult.Data)
                {
                    Console.WriteLine("Araba Adı : {3} -- Model Yılı : {0}  --  Açıklama : {1}  -- Fiyat : {2} ", car.ModelYear, car.Description, string.Format("{0:N2}", car.DailyPrice), car.CarName);
                }
            }


            Console.WriteLine("\n----- Araba Renkleri -----\n");

            var colorResult = colorManager.GetAll();

            if (colorResult.Success)
            {
                foreach (var color in colorResult.Data)
                {
                    Console.WriteLine("Araç Renkleri : {0}", color.ColorName);
                }
            }
           


            //Console.WriteLine("\n----- Araç Ekleme  -----\n");

            //Car car1 = new Car
            //{
            //    BrandId = 2,
            //    ColorId = 2,
            //    CarName = "E200",
            //    DailyPrice = 250,
            //    Description = "E200 Benzinli Kare Motor",
            //    ModelYear = 1984
            //};

            //carManager.Add(car1);

            //Console.WriteLine("\n----- Renk  CRUD İşlemleri  -----\n");
            //Color color1 = new Color
            //{
            //    ColorName = "Lacivert"
            //};
            //colorManager.Add(color1);



            //colorManager.Update(new Color { Id = 1008, ColorName = "Gri" });

            //Console.WriteLine(colorManager.GetById(3).Data.ColorName);
            //colorManager.Delete(new Color { Id = 1012 });


            //Console.WriteLine("\n----- Marka  CRUD İşlemleri  -----\n");

            //brandManager.Add(new Brand { BrandName = "Fiat" });

            //brandManager.Update(new Brand { Id = 6, BrandName = "Honda" });

            //brandManager.Delete(new Brand { Id = 7 });

            //Console.WriteLine(brandManager.GetById(4).Data.BrandName);
        }
    }
}
