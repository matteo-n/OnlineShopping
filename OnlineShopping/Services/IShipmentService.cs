using OnlineShopping.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopping.Services
{
    public interface IShipmentService
    {
        void ArrangeShipment(Order order);
    }
}
