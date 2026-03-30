using OnlineShopping.Models;
using OnlineShopping.Services;
using OnlineShopping.Strategies;
using System;

public class OrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IPaymentService _paymentService;
    private readonly IShipmentService _shipmentService;
    private readonly OnlineShoppingContext _context;
    private readonly ILogger _logger;

    public OrderService(
        IOrderRepository orderRepository,
        IPaymentService paymentService,
        IShipmentService shipmentService,
        OnlineShoppingContext context,
        ILogger logger)
    {
        _orderRepository = orderRepository;
        _paymentService = paymentService;
        _shipmentService = shipmentService;
        _context = context;
        _logger = logger;
    }

    public void Checkout(Cart cart, IDiscountStrategy discountStrategy)
    {
        using var transaction = _context.Database.BeginTransaction();
        try
        {
            var order = CreateOrderFromCart(cart);
            _orderRepository.Add(order);
            _orderRepository.SaveChanges();

            var total = order.GetFinalTotal(discountStrategy);
            if (!_paymentService.ProcessPayment(total))
            {
                throw new Exception("Payment failed");
            }

            _shipmentService.ArrangeShipment(order);

            transaction.Commit();
            _logger.Log("Checkout completed successfully.");
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            _logger.Log($"Checkout failed: {ex.Message}");
        }
    }

    private Order CreateOrderFromCart(Cart cart)
    {
        var order = new Order();
        foreach (var item in cart.Items)
        {
            order.OrderItems.Add(new OrderItem
            {
                ProductId = item.Product.Id,
                Price = item.Product.Price,
                Quantity = item.Quantity
            });
        }
        return order;
    }
}