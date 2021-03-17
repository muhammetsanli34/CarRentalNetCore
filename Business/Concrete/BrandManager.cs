using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        [SecuredOperation("brand.add,admin")]
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
            if (brand.Name.Length<2)
            {
                return new ErrorResult(Messages.BrandNameInvalid);
            }
            _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);
        }

        [SecuredOperation("brand.add,admin")]
        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);

        }

        public IDataResult<List<Brand>> GetAll()
        {
            
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
        }

        public IDataResult<Brand> GetById(int id)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(p=>p.Id==id));
        }

        [SecuredOperation("brand.add,admin")]
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Update(Brand brand)
        {
            return new SuccessResult(Messages.BrandUpdated);
        }

    
    }
}
