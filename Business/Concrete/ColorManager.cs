﻿using Business.Abstract;
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

        public void Add(Color entity)
        {
            _colorDal.Add(entity);
        }
        public void Update(Color entity)
        {
            _colorDal.Update(entity);
        }
        public void Delete(Color entity)
        {
            _colorDal.Delete(entity);
        }
        public List<Color> GetAll()
        {
            return _colorDal.GetAll();
        }
        public Color GetById(int id)
        {
            return _colorDal.Get(c => c.Id == id);
        }

       
    }
}
