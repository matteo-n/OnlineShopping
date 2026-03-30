using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopping.Services
{
    public class PaymentService: IPaymentService
    {
        public bool ProcessPayment(decimal amount)
        {
            return true;
        }
    }
}
