using OnlineShopping.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopping.Models
{
    public class Order
    {
        public int Id { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new();

        public decimal GetFinalTotal(IDiscountStrategy discountStrategy)
        {
            decimal baseTotal = OrderItems.Sum(item => item.Price * item.Quantity);
            return discountStrategy.ApplyDiscount(baseTotal);
        }
    }
}
