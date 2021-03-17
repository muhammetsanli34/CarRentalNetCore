using Business.Abstract;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.BusinessAspects.Autofac;

namespace Business.Concrete
{
    class CarImageManager : ICarImageService
    {
       
        ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
          
        }
        [SecuredOperation("carimage.add,admin")]
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile file,CarImage carImage)
        {
            var result = BusinessRules.Run(CheckIfImageLimitExceded(carImage.CarId));

            if (result!=null)
            {
                return result;
            }
            carImage.ImagePath = FileHelper.Add(file);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.ImageAdded);
        }

        [SecuredOperation("carimage.add,admin")]
        public IResult Delete(CarImage carImage)
        {
            FileHelper.Delete(carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(CheckIfThereIsPıcture(carId));
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(i => i.Id == id));
        }

        [SecuredOperation("carimage.add,admin")]
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(IFormFile file, CarImage carImage)
        {
            var oldImage = _carImageDal.Get(i => i.Id == carImage.Id);
            var oldPath = oldImage.ImagePath;
            _carImageDal.Update(carImage);
            FileHelper.Update(file, oldPath);
            return new SuccessResult(); 
        }
        
        private IResult CheckIfImageLimitExceded(int carId)
        {
            var result = _carImageDal.GetAll(i => i.CarId == carId).Count;
            if (result>=5)
            {
                return new ErrorResult(Messages.ImageLimitExceded);
            }
            return new SuccessResult();
        }
        private List<CarImage> CheckIfThereIsPıcture(int carId)
        {
            string path = Environment.CurrentDirectory + @"\Static\Images\logo.jpg";
            var result = _carImageDal.GetAll(i=>i.CarId==carId) .Any();
            if (result)
            {
               
                return new List<CarImage> { new CarImage { Date=DateTime.Now, ImagePath=path} };
            }
            return _carImageDal.GetAll(i => i.CarId == carId);
        }
    }
}
