using System.Threading.Tasks;

namespace HBApp.Core.Interfaces
{
    public interface IProductService
    {
        Task<Product> AddProductAsync(string productCode, decimal price, int stock);
        Task<Product> GetProductByCodeAsync(string productCode);

    }
}
