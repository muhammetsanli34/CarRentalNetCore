using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car {Id=8,ColorId=2,BrandId=2,ModelYear="2011",DailyPrice=170,Description="Dizel"};
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine(item.Id);
            }
                
            Console.ReadLine();
           
            
        }
    }
}
