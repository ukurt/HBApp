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
        ICampaignService _campaignService;

        public GetProductInfoExecutor(IProductService productService, ICampaignService campaignService)
        {
            _productService = productService;
            _campaignService = campaignService;
        }

        public async Task<BaseDto> Execute(BaseDto baseDto)
        {
            var dtoToExecute = (GetProductInfo)baseDto;
            var product = await _productService.GetProductByCodeAsync(dtoToExecute.ProductCode);
            var campaing = await _campaignService.GetActiveCampaignForThisProduct(dtoToExecute.ProductCode);
            dtoToExecute.Stock = product.Stock;
            dtoToExecute.Price= product.Price;
            if (campaing != null)
            {
                dtoToExecute.Price = campaing.ProductPrice; 
            }
            return dtoToExecute;
        }
    }
}

