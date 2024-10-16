using System.Threading.Tasks;
using MassTransit;
using Purchases.Domain.Services;
using RtuItLab.Infrastructure.MassTransit.Purchases.Responses;
using RtuItLab.Infrastructure.Models.Identity;

namespace Purchases.API.Consumers
{
    public class GetTransactions : PurchasesBaseConsumer, IConsumer<User>
    {
        public GetTransactions( IPurchasesService purchasesService) : base(purchasesService)
        {
            
        }
        public async Task Consume(ConsumeContext<User> context)
        {
            var transactions = await PurchasesService.GetTransactions(context.Message);
            await context.RespondAsync(new GetTransactionsResponse() { Transactions = transactions });
        }
    }
}
