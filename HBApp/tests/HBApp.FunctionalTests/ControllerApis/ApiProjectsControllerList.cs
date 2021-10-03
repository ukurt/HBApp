using Ardalis.HttpClientTestExtensions;
using HBApp.Web;
using HBApp.Web.ApiModels;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace HBApp.FunctionalTests.ControllerApis
{
    [Collection("Sequential")]
    public class ProductCreate : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public ProductCreate(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task ReturnsOneProject()
        {
            var result = await _client.GetAndDeserialize<IEnumerable<ProductDTO>>("/api/products");

            Assert.Equal(1, result.Count());
            Assert.Contains(result, i => i.ProductCode == "");
        }
    }
}
