using Core.Business;
using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService : IBusinessRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
        User GetByMail(string email);
    }
}
