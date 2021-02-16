using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }
        

        public void Add(Entities.Concrete.Color color)
        {
            _colorDal.Add(color);
        }

        public void Delete(Entities.Concrete.Color color)
        {
            throw new NotImplementedException();
        }

        public List<Entities.Concrete.Color> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            throw new NotImplementedException();
        }
    }
}
