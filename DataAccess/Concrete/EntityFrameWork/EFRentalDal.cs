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
    public class EFRentalDal : EFEntityRepositoryBase<Rental, ReCapContext>, IRentalDal
    {
        public List<RentalDto> GetAllRentalDetail()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from r in context.Rentals
                             join car in context.Cars on r.CarId equals car.Id
                             join c in context.Customers on r.CustomerId equals c.Id
                             join b in context.Brands on car.BrandId equals b.Id
                             join u in context.Users on c.UserId equals u.Id
                             select new RentalDto
                             {
                                 Id = r.Id,
                                 BrandName = b.Name,
                                 CustomerName = u.FirstName + " " + u.LastName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate.Value,

                             };
                return result.ToList();
            }
        }
    }
}
