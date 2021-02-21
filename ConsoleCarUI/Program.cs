using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleCarUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //BrandTest();
            ColorTest();

        }

        private static void ColorTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarsByColorId(5);
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.ColorId + "/" + car.Id);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        //private static void BrandTest()
        //    {
        //        BrandManager brandManager = new BrandManager(new EfBrandDal());
        //        foreach (var brand in brandManager.GetAll())
        //        {
        //            Console.WriteLine(brand.BrandName);
        //        }
        //    }

        

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            //8.gün
            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine(car.Description);
            //}

            //carManager.Add(new Car { BrandId = 3, ColorId = 1, ModelYear = "2020", DailyPrice = 200000, Description = "HONDA" });
            //9.Gün
            //foreach (var car in carManager.GetCarDetails())
            //{
            //    Console.WriteLine(car.CarDescription + "/" + car.ColorName );
            //}

            var result = carManager.GetCarDetails();
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarDescription + "/" + car.ColorName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }
    }
}
