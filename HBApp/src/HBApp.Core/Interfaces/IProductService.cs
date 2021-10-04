using HBApp.Core.Dto;
using System.Threading.Tasks;

namespace HBApp.Core.Interfaces
{
    public interface IProductService
    {
        Task<Product> AddProductAsync(CreateProductDto createProductDto);
        Task<Product> GetProductByCodeAsync(string productCode);

    }
}
