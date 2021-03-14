using Core.DataAccess.EntityFrameWork;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class EFCarDal : EFEntityRepositoryBase<Car, ReCapContext>, ICarDal
    {
        public List<CarDetailDto> GetAllCarDetail(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Cars
                             join co in context.Colors on c.ColorId equals co.Id
                             join b in context.Brands on c.BrandId equals b.Id
                             select new CarDetailDto
                             {
                                 CarId = c.Id,
                                 BrandId = c.BrandId,
                                 ColorId=c.ColorId,
                                 CarName = c.CarName,
                                 BrandName = b.Name,
                                 ColorName = co.Name,
                                 DailyPrice = c.DailyPrice
                             };
                return filter == null
                    ? result.ToList()
                    : result.Where(filter).ToList();
            }
        }
    }
}
