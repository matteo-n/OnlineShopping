using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopping.Strategies
{
    public interface IDiscountStrategy
    {
        decimal ApplyDiscount(decimal totalAmount);
    }
}
