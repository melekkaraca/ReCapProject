﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFrameWork;
using Entities.Concrete;
using System;
using System.Collections.Generic;
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

        public IResult Add(Color entity)
        {
            _colorDal.Add(entity);
            return new SuccessResult($"{entity.Name} {Messages.Added}");
        }
        public IResult Update(Color entity)
        {
            _colorDal.Update(entity);
            return new SuccessResult($"{entity.Name} {Messages.Updaded}");
        }
        public IResult Delete(int id)
        {
            var entity = GetById(id).Data;
            _colorDal.Delete(entity);
            return new SuccessResult($"{entity.Name} {Messages.Deleted}");
        }
        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
        }
        public IDataResult<Color> GetById(int id)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.Id == id));
        }
    }
}
