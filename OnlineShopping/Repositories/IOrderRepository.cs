using OnlineShopping.Models;
using System;
using System.Collections.Generic;


public interface IOrderRepository
{
    void Add(Order order);
    List<Order> GetAllWithItems();
    void SaveChanges();
}
