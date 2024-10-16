using System.Threading.Tasks;
using MassTransit;
using RtuItLab.Infrastructure.MassTransit.Shops.Requests;
using RtuItLab.Infrastructure.MassTransit.Shops.Responses;
using Shops.Domain.Services;

namespace Shops.API.Consumers
{
    public class GetAllShops : ShopsBaseConsumer, IConsumer<GetAllShopsRequest>
    {
        public GetAllShops(IShopsService shopsService) : base(shopsService)
        {
        }
        public async Task Consume(ConsumeContext<GetAllShopsRequest> context)
        {
            var shops = ShopsService.GetAllShops();
            await context.RespondAsync(new GetShopsResponse() { Shops = shops });
        }
    }
}
