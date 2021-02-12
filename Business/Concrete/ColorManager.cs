using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using Business.Abstract;
using Business.Constant;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ColorManager:IColorService
    {
        private IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }


        public IDataResult<List<Color>> GetAll()
        {
            if (DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<List<Color>>(Messages.Maintenance);
            }
            else
            {
                return new SuccessDataResult<List<Color>>(_colorDal.GetAll(),Messages.ColorListed);
            }
        }

        public IResult Add(Color color)
        {
            if (color.ColorName.Length<2)
            {
                return new ErrorResult(Messages.ColorInvalid);
            }
            else
            {
                _colorDal.Add(color);
                return new SuccessResult(Messages.ColorAdded);
            }
           
        }

        public IResult Update(Color color)
        {
            if (color.ColorName.Length < 2)
            {
                return new ErrorResult(Messages.ColorInvalid);
            }
            else
            {
                _colorDal.Update(color);
                return new SuccessResult(Messages.ColorUpdated);
            }
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(Messages.ColorDeleted);

        }

        public IDataResult<Color> GetById(int colorId)
        {
             return new SuccessDataResult<Color>(_colorDal.Get(x=>x.Id==colorId));
        }
    }
}
