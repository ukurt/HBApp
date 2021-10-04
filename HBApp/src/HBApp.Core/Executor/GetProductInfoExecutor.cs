using HBApp.Core.Dto;
using HBApp.Core.Interfaces;
using HBApp.Core.ParseStrategy;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HBApp.Core.Services
{
    public class GetProductInfoExecutor : IExecutor
    {
        IProductService _productService;
        public GetProductInfoExecutor(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<BaseDto> Execute(BaseDto baseDto)
        {
            var dtoToExecute = (GetProductInfo)baseDto;
            var product = await _productService.GetProductByCodeAsync(dtoToExecute.ProductCode);
            return null;
        }
    }
}
