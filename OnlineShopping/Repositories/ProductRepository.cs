using OnlineShopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;

public class ProductRepository : IProductRepository
{
    private readonly OnlineShoppingContext _context;

    public ProductRepository(OnlineShoppingContext context)
    {
        _context = context;
    }

    public void Add(Product product)
    {
        _context.Products.Add(product);
    }

    public List<Product> Search(string keyword)
    {
        return _context.Products.Where(p => p.Name.Contains(keyword)).ToList();
    }

    public Product? GetById(int id)
    {
        return _context.Products.Find(id);
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}
