using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopping.Strategies
{
    public class PercentageDiscountStrategy:IDiscountStrategy
    {
        private readonly decimal _percentage;

        public PercentageDiscountStrategy(decimal percentage)
        {
            _percentage = percentage;
        }

        public decimal ApplyDiscount(decimal totalAmount)
        {
            return totalAmount - (totalAmount * _percentage / 100);
        }
    }
}
