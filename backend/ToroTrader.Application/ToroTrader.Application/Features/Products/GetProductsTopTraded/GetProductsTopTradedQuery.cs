﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ToroTrader.Application.Features.Products.GetProductsTopTraded
{
    public class GetProductsTopTradedQuery
    {

        [DefaultValue(1)]
        [FromQuery(Name = "pageNumber")]
        public int pageNumber { get; set; }

        [DefaultValue(10)]
        [FromQuery(Name = "pageSize")]
        public int pageSize { get; set; }
    }
}
