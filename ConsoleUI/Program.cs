using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //BrandTest();
            //UserTest();
            Console.ReadLine();
        }

        private static void UserTest()
        {
            User user = new User
            {
                Id = 1,
                FirstName = "Muhammet",
                LastName = "Şanlı",
                Email = "muhammetsanli34@gmail.com",
                Password = "1903"
            };

            UserManager userManager = new UserManager(new EfUserDal());
            var result = userManager.GetById(1);
            Console.WriteLine(result.Data.Id);
        }

        private static void BrandTest()
        {
            Brand brand = new Brand { Id = 4, Name = "Renault" };
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result = brandManager.Add(brand);

            if (result.Success)
            {
                Console.WriteLine(brand.Id + " / " + brand.Name);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void CarTest()
        {
            Car car = new Car { Id = 16, BrandId = 1, CarName = "C", DailyPrice = 60, ColorId = 2, Description = "Dizel", ModelYear = "2011" };
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.Add(car);
            if (result.Success)
            {
                Console.WriteLine(car.CarName + " / " + car.DailyPrice);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            Console.ReadLine();
        }
    }
}
