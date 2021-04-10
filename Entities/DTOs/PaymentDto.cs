using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class PaymentDto : IDto
    {
        public string CardName { get; set; }
        public int CardNumber { get; set; }
        public int CardDateMonth { get; set; }
        public int CardDateYear { get; set; }
        public int CardCvv { get; set; }
        public int TotalPrice { get; set; }

    }
}
