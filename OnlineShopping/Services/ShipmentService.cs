using OnlineShopping.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopping.Services
{
    public class ShipmentService: IShipmentService
    {
        private readonly ILogger _logger;

        public ShipmentService(ILogger logger)
        {
            _logger = logger;
        }
        public void ArrangeShipment(Order order)
        {
            _logger.Log($"Shipment arrange for Order ID {order.Id}");
        }
    }
}
