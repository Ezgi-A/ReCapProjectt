using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.Entity_FrameWork;
using Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarTest();
            Console.WriteLine("----------------------------------");
            BrandTest();
            Console.WriteLine("----------------------------------");
            ColorTest();
            Console.WriteLine("----------------------------------");

            CarManager carManager2 = new CarManager(new EFCarDal());
            var result4 = carManager2.GetCarDetails();
            if (result4.Success == true)
            {
                foreach (var car in result4.Data)
                {
                    Console.WriteLine("Car Name: " + car.CarName + " / Brand Name : " + car.BrandName + " / Color : " + car.ColorName + " / Daily Price : " + car.DailyPrice);

                }
            }

        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EFColorDal());
            Color color1 = new Color { ColorName = "Purple" };
            var result3 = colorManager.GetAll();
            if (result3.Success == true)
            {
                foreach (var color in result3.Data)
                {
                    Console.WriteLine("ColorId: " + color.ColorId + " Brand Name: " + color.ColorName);


                }
            }

            colorManager.GetById(1);
            colorManager.Add(color1);
            Console.WriteLine("After Adding");

            if (result3.Success == true)
            {
                foreach (var color in result3.Data)
                {
                    Console.WriteLine("ColorId: " + color.ColorId + " Brand Name: " + color.ColorName);


                }
            }
            Console.WriteLine("After Deleting");

            if (result3.Success == true)
            {
                foreach (var color in result3.Data)
                {
                    Console.WriteLine("ColorId: " + color.ColorId + " Brand Name: " + color.ColorName);


                }
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EFBrandDal());
            Brand brand1 = new Brand { BrandName = "Volvo" };
            var result2 = brandManager.GetAll();
            if (result2.Success == true)
            {
                foreach (var brand in result2.Data)
                {
                    Console.WriteLine("BrandId: " + brand.BrandId + " Brand Name: " + brand.BrandName);


                }
            }

            brandManager.GetById(3);
            brandManager.Add(brand1);
            Console.WriteLine("After Adding");

            if (result2.Success == true)
            {
                foreach (var brand in result2.Data)
                {
                    Console.WriteLine("BrandId: " + brand.BrandId + " Brand Name: " + brand.BrandName);


                }
            }
            brandManager.Delete(brand1);
            if (result2.Success == true)
            {
                foreach (var brand in result2.Data)
                {
                    Console.WriteLine("BrandId: " + brand.BrandId + " Brand Name: " + brand.BrandName);


                }
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EFCarDal());
            Car car2 = new Car {  BrandId = 2, ColorId = 1, CarName = "Manuel", ModelYear = 2000, DailyPrice = 35000, Description = "1.2 TSI" };
            var result = carManager.GetAll();
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("CarId: " + car.CarId + " Car Name: " + car.CarName + "  Car BrandId: " + car.BrandId + " Car ColorId: " + car.ColorId + " Car DailyPrice: " +
                       car.DailyPrice + " Car Description: " + car.Description);

                }

            }
            carManager.GetById(2);

            carManager.Add(car2);
            Console.WriteLine("After Adding");
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("CarId: " + car.CarId + " Car Name: " + car.CarName + "  Car BrandId: " + car.BrandId + " Car ColorId: " + car.ColorId + " Car DailyPrice: " +
                       car.DailyPrice + " Car Description: " + car.Description);

                }

            }
            Console.WriteLine("After deleting-----------------");
            carManager.Delete(car2);
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("CarId: " + car.CarId + " Car Name: " + car.CarName + "  Car BrandId: " + car.BrandId + " Car ColorId: " + car.ColorId + " Car DailyPrice: " +
                       car.DailyPrice + " Car Description: " + car.Description);

                }

            }
        }
    }
}
