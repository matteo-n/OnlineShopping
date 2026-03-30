using Microsoft.EntityFrameworkCore;
using OnlineShopping.Models;
using System.Collections.Generic;
using System.Linq;

public class OrderRepository : IOrderRepository
{
    private readonly OnlineShoppingContext _context;

    public OrderRepository(OnlineShoppingContext context)
    {
        _context = context;
    }

    public void Add(Order order)
    {
        _context.Orders.Add(order);
    }

    public List<Order> GetAllWithItems()
    {
        return _context.Orders.Include(o => o.OrderItems).ThenInclude(oi => oi.Product).ToList();
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}