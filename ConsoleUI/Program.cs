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
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());

            Console.WriteLine("----- Araba Markaları ----- \n");


            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(" Araç Markaları : {0}",brand.BrandName);
            }



            Console.WriteLine("\n----- Araba Özellikleri ve Fiyatı -----\n");

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Araba Adı : {3} -- Model Yılı : {0}  --  Açıklama : {1}  -- Fiyat : {2} ",car.ModelYear,car.Description,string.Format("{0:N2}", car.DailyPrice),car.CarName);
            }

            Console.WriteLine("\n----- Araba Renkleri -----\n");

            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine("Araç Renkleri : {0}",color.ColorName);
            }


            Console.WriteLine("\n----- Araç Ekleme  -----\n");

            Car car1 = new Car
            {
                BrandId = 2,
                ColorId = 2,
                CarName = "E200",
                DailyPrice = 250,
                Description = "E200 Benzinli Kare Motor",
                ModelYear = 1984
            };

           carManager.Add(car1);
            

        }
    }
}
