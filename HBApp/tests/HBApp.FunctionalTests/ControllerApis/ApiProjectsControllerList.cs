using HBApp.Web;
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
            var result = await _client.GetAsync("/api/Product/test");
        }
    }
}
