using Core.DataAccess.EntityFrameWork;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class EFUserDal : EFEntityRepositoryBase<User, ReCapContext>, IUserDal
    {
    }
}
