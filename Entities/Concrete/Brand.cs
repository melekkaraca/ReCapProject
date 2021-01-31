using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Brand : IEntity
    {
        public int id { get; set; }
        public int BrandName { get; set; }
    }
}
