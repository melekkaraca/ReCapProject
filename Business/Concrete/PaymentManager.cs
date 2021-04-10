using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Transaction;
using Core.Utilities.Results;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        [TransactionScopeAspect]
        public IResult Pay(PaymentDto paymentDto)
        {
            if (paymentDto.TotalPrice < 600)
            {
                return new SuccessResult(Messages.PaymentReceived);
            }

            return new ErrorResult(Messages.PaymentCouldNotBeReceived);
        }
    }
}
