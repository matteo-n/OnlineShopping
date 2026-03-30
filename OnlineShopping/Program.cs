using OnlineShopping.Models;
using OnlineShopping.Services;
using OnlineShopping.Strategies;
using System;

public class Program
{
    private static ILogger _logger = new ConsoleLogger();
    private static OnlineShoppingContext _context = new OnlineShoppingContext();
    private static IProductRepository _productRepository = new ProductRepository(_context);
    private static IOrderRepository _orderRepository = new OrderRepository(_context);
    private static Cart _cart = new Cart();

    public static void Main()
    {
        bool isRunning = true;
        while (isRunning)
        {
            _logger.Log("1.Add Product|2.Search|3.Add to Cart|4.View Cart|5.Checkout|6.Exit");
            string choice = Console.ReadLine() ?? string.Empty;
            isRunning = ProcessChoice(choice);
        }
    }

    private static bool ProcessChoice(string choice)
    {
        switch (choice)
        {
            case "1": HandleAddProduct(); return true;
            case "2": HandleSearchProduct(); return true;
            case "3": HandleAddToCart(); return true;
            case "4": DisplayCart(); return true;
            case "5": HandleCheckout(); return true;
            case "6": return false;
            default: _logger.Log("Invalid option"); return true;
        }
    }

    private static void HandleAddProduct()
    {
        _logger.Log("Enter name:");
        string name = Console.ReadLine() ?? string.Empty;
        _logger.Log("Enter price:");
        if (decimal.TryParse(Console.ReadLine(), out decimal price))
        {
            _productRepository.Add(new Product { Name = name, Price = price });
            _productRepository.SaveChanges();
            _logger.Log("Product added.");
        }
    }

    private static void HandleSearchProduct()
    {
        _logger.Log("Enter keyword:");
        string keyword = Console.ReadLine() ?? string.Empty;
        var products = _productRepository.Search(keyword);
        foreach (var p in products)
        {
            _logger.Log($"[{p.Id}] {p.Name} - {p.Price}");
        }
    }

    private static void HandleAddToCart()
    {
        _logger.Log("Enter Product ID:");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var product = _productRepository.GetById(id);
            if (product != null)
            {
                _cart.AddProduct(product, 1);
                _logger.Log("Added to cart.");
            }
        }
    }

    private static void DisplayCart()
    {
        foreach (var item in _cart.Items)
        {
            _logger.Log($"{item.Product.Name} x {item.Quantity} = {item.Product.Price * item.Quantity}");
        }

        if (_cart.IsLargeOrder())
        {
            _logger.Log("This is a large order (> 1000).");
        }
    }

    private static void HandleCheckout()
    {
        var paymentService = new PaymentService();
        var shipmentService = new ShipmentService(_logger);
        var orderService = new OrderService(_orderRepository, paymentService, shipmentService, _context, _logger);
        var discountStrategy = new NoDiscountStrategy();

        orderService.Checkout(_cart, discountStrategy);
        _cart.Clear();
    }
}