﻿using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
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

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand entity)
        {
            _brandDal.Add(entity);
            return new SuccessResult($"{entity.Name } { Messages.Added}");
        }
        public IResult Update(Brand entity)
        {
            _brandDal.Update(entity);
            return new SuccessResult($"{entity.Name } { Messages.Updaded}");
        }
        public IResult Delete(int id)
        {
            var entity = GetById(id).Data;
            _brandDal.Delete(entity);
            return new SuccessResult($"{entity.Name} {Messages.Deleted}");
        }
        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(),Messages.Listed);
        }
        public IDataResult<Brand> GetById(int id)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(b=>b.Id == id));
        }
    }
}
