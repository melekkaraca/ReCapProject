﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class RentalDto : IDto
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string CustomerName { get; set; }
    }
}
