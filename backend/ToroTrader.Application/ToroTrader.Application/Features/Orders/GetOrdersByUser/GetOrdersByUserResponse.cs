﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToroTrader.Application.Features.Orders.GetOrdersByUser
{
    public class GetOrdersByUserResponse
    {
        public Guid Id { get; set; }
        public string BondAsset { get; set; }
        public string Index { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; }
        public decimal UnitPrice { get; set; }
    }

    public class GetOrdersByUsersResponse
    {
        public List<GetOrdersByUserResponse> Items { get; set; } = [];
        public int TotalElements { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
