using OnlineShopping.Models;
using System;
using System.Collections.Generic;
using System.Text;

public interface IProductRepository
{
    void Add(Product product);
    List<Product> Search(string keyword);
    Product? GetById(int id);
    void SaveChanges();
}
