using Business.Abstract;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        
        IRentalDal _rentalDal;
     
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            var result=BusinessRules.Run(CheckIfCarIsReturned(rental));
            if (result!=null)
            {
                return result;
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(p => p.Id == id));
        }

        public IDataResult<Rental> GetCarsByCarId(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(p => p.CarId == id));
        }

        public IDataResult<Rental> GetCarsByCustomerId(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(p => p.CustomerId == id));
        }
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetail()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }

        private IResult CheckIfCarIsReturned(Rental rental)
        {
            var result = _rentalDal.GetAll(c => c.CarId == rental.CarId);
            foreach (var car in result)
            {
                var isPast=DateTime.Compare(rental.RentDate,car.ReturnDate);
                if (isPast==-1)
                {
                    return new ErrorResult(Messages.CarNotReturned);
                }
            }
            return new SuccessResult();
        }

    }
}
