using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car,ReCapContext>,ICarDal
    {
            public List<CarDetailDto> GetCarDetails()
            {
                using (ReCapContext context = new ReCapContext())
                {
                var result = from ca in context.Cars
                             join br in context.Brands on ca.BrandId equals br.Id
                             join co in context.Colors on ca.ColorId equals co.Id
                             select new CarDetailDto
                             {
                                 CarName = ca.CarName,
                                 ColorName = co.Name,
                                 BrandName=br.Name,
                                 DailyPrice = ca.DailyPrice
                             };
                    return result.ToList();
                }
                
                    
            }

    }
            
 }
