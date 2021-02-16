using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id=1,BrandId=1,ColorId=1,DailyPrice=90,ModelYear="2018",Description="Otomatik Dizel"},
                new Car{Id=2,BrandId=1,ColorId=1,DailyPrice=160,ModelYear="2019",Description="Otomatik Hibrit"},
                new Car{Id=3,BrandId=1,ColorId=1,DailyPrice=70,ModelYear="2012",Description="Manuel Benzinli"},
                new Car{Id=4,BrandId=1,ColorId=1,DailyPrice=100,ModelYear="2016",Description="Otomatik Dizel"},
                new Car{Id=5,BrandId=1,ColorId=1,DailyPrice=120,ModelYear="2019",Description="Otomatik Benzinli"}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }


        public void Delete(Car car)
        {
            var deleteToCars = _cars.SingleOrDefault(p => p.Id == car.Id);
            _cars.Remove(deleteToCars);
        }

        

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(Car car)
        {
            var getToCars = _cars.SingleOrDefault(p => p.Id == car.Id);
            return getToCars;
        }

        public Car GetById(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            var updateToCars = _cars.SingleOrDefault(p => p.Id == car.Id);
            updateToCars.Id = car.Id;
            updateToCars.BrandId = car.BrandId;
            updateToCars.ColorId = car.ColorId;
            updateToCars.DailyPrice = car.DailyPrice;
            updateToCars.Description = car.Description;
            updateToCars.ModelYear = car.ModelYear;
        }
    }
}
