using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopping.Services
{
    public interface IPaymentService
    {
        bool ProcessPayment(decimal amount);
    }
}
