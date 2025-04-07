using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ToroTrader.Application.Features.Products.GetProducts
{
    public class GetProductsQuery
    {

        [DefaultValue(1)]
        [FromQuery(Name = "pageNumber")]
        public int pageNumber { get; set; } = 1;

        [DefaultValue(10)]
        [FromQuery(Name = "pageSize")]
        public int pageSize { get; set; } = 10;

        [FromQuery(Name = "bondAsset")]
        public string BondAsset { get; set; }

        [FromQuery(Name = "index")]
        public string Index { get; set; }
    }
}
