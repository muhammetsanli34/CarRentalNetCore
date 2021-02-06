using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car {Id=5,ColorId=2,BrandId=2,ModelYear="2011",DailyPrice=170,Description="Dizel"};
            CarManager carManager = new CarManager(new InMemoryCarDal());
            foreach (var caritem in carManager.GetAll())
            {
                Console.WriteLine(caritem.Description);
            }
            
            
        }
    }
}
