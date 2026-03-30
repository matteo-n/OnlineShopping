using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopping.Models
{
    public class CartItem
    {
        public Product Product { get; set; } = null!;
        public int Quantity { get; set; }
    }
}
