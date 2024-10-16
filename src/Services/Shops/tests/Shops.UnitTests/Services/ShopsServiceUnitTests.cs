using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RtuItLab.Infrastructure.Exceptions;
using Shops.DAL.Data;
using Shops.Domain.Services;
using Xunit;

namespace Shops.UnitTests.Services
{
    public class ShopsServiceUnitTests
    {
        private readonly ShopsService _shopsService;

        public ShopsServiceUnitTests()
        {
            var options = new DbContextOptionsBuilder<ShopsDbContext>()
                .UseInMemoryDatabase("test_shops");
            var shopsContext = new ShopsDbContext(options.Options);
            _shopsService = new ShopsService(shopsContext);
        }

        [Fact] 
        public void GetAllShop_Expected_Shops_And_Null_products()
        {
            var response = _shopsService.GetAllShops();
            var shops = response;
            Assert.NotNull(shops);
            Assert.Null(shops.First().Products);
        }
        [Fact]
        public async Task GetProductsByShopId_Expected_Shops_And_Included_All_products()
        {
            var response = await _shopsService.GetProductsByShop(1);
            var product = response;
            Assert.NotNull(product);
            Assert.NotNull(product.First());
        }
        [Fact]
        public async Task GetProductsByShopId_Expected_Throw_NotFoundException()
        {
            var action = _shopsService.GetProductsByShop(1251252151);           
            await Assert.ThrowsAsync<NotFoundException>(() => action);
        }
        [Fact]
        public async Task GetProductsByCategoryInShop_Expected_Success()
        {
            var response = await _shopsService.GetProductsByCategory(1,"одежда");
            var product = response;
            Assert.NotNull(product);
            Assert.NotNull(product.First());
        }
    }
}