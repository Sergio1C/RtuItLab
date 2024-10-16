using System.Collections.Generic;
using RtuItLab.Infrastructure.Models.Shops;

namespace RtuItLab.Infrastructure.MassTransit.Shops.Responses
{
    public class GetShopsResponse
    {
        public ICollection<Shop> Shops { get; set; }
    }
}
