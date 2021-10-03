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
            var result = await _client.GetAndDeserialize<ProductDTO>("/api/Product/test");

            Assert.Equal("test",result.ProductCode);
        }
    }
}
