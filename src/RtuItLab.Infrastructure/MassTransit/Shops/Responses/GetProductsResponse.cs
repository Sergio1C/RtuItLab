﻿using System.Collections.Generic;
using RtuItLab.Infrastructure.Models.Shops;

namespace RtuItLab.Infrastructure.MassTransit.Shops.Responses
{
    public class GetProductsResponse
    {
        public ICollection<Product> Products { get; set; }
    }
}
