using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToroTrader.Application.Features.Orders.CreateOrder
{
    public class CreateOrderRequest
    {
        [DefaultValue("")]
        public string ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
