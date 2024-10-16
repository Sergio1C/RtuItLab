﻿using System.Threading.Tasks;
using MassTransit;
using RtuItLab.Infrastructure.MassTransit.Shops.Requests;
using RtuItLab.Infrastructure.MassTransit.Shops.Responses;
using Shops.Domain.Services;

namespace Shops.API.Consumers
{
    public class GetProductsByCategory : ShopsBaseConsumer, IConsumer<GetProductsByCategoryRequest>
    {
        public GetProductsByCategory( IShopsService shopsService) : base(shopsService)
        {
        }

        public async Task Consume(ConsumeContext<GetProductsByCategoryRequest> context)
        {
            var products = await ShopsService.GetProductsByCategory(context.Message.ShopId, context.Message.Category);
            await context.RespondAsync(new GetProductsResponse() { Products = products });
        }
    }
}
