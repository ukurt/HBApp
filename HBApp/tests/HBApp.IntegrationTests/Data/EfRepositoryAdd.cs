using HBApp.Core;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace HBApp.IntegrationTests.Data
{
    public class EfRepositoryAdd : BaseEfRepoTestFixture
    {
        [Fact]
        public async Task AddsProjectAndSetsId()
        {
            var testProductCode = "testProduct";
            var repository = GetRepository();
            var product = new Product(testProductCode, 100,100);

            await repository.AddAsync(product);

            var newProduct = (await repository.ListAsync<Product>())
                            .FirstOrDefault();

            Assert.Equal(testProductCode, newProduct.ProductCode);
            Assert.True(newProduct?.Id > 0);
        }
    }
}
