using System;
using Business.Concrete;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            BrandManager brandManager = new BrandManager(new InMemoryBrandDal());
            ColorManager colorManager = new ColorManager(new InMemoryColorDal());

            Console.WriteLine("----- Araba Markaları ----- \n");


            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(" Araç Markaları : {0}",brand.BrandName);
            }



            Console.WriteLine("\n----- Araba Özellikleri ve Fiyatı -----\n");

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Model Yılı : {0}  --  Açıklama : {1}  -- Fiyat : {2} ",car.ModelYear,car.Description,car.DailyPrice);
            }

            Console.WriteLine("\n----- Araba Renkleri -----\n");

            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine("Araç Renkleri : {0}",color.ColorName);
            }


        }
    }
}
