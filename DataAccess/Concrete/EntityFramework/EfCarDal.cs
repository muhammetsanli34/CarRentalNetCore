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
                    var result = from c in context.Cars
                                 join b in context.Brands
                                 on c.BrandId equals b.Id
                                 join color in context.Colors
                                 on c.ColorId equals color.Id
                                 join image in context.CarImages
                                 on c.Id equals image.CarId
                                 select new CarDetailDto
                                 {
                                     CarName=c.CarName,
                                     BrandName=b.Name,
                                     ColorName=color.Name,
                                     DailyPrice=c.DailyPrice,
                                     CarImage=image.ImagePath
                                 };
                    return result.ToList();
                }
                
                    
            }

    }
            
 }
