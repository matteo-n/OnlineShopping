using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OnlineShopping.Models
{
    public class Cart
    {
        public List<CartItem> Items { get; } = new();
        
        public void AddProduct(Product product,int quantity)
        {
            var existingItem = Items.FirstOrDefault(i => i.Product.Id == product.Id);
            if(existingItem!=null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                Items.Add(new CartItem { Product = product, Quantity = quantity });
            }
        }

        public decimal GetTotalBasePrice()
        {
            return Items.Sum(i => i.Product.Price * i.Quantity);
        }

        public bool IsLargeOrder()
        {
            return GetTotalBasePrice() > 1000;
        }

        public void Clear()
        {
            Items.Clear();
        }
    }
}
