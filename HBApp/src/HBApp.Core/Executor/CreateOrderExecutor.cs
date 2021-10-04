using HBApp.Core.Dto;
using HBApp.Core.Interfaces;
using HBApp.Core.ParseStrategy;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HBApp.Core.Services
{
    public class CreateOrderExecutor : IExecutor
    {
        IOrderService _orderService;
        IProductService _productService;
        ICampaignService _campaignService;


        public CreateOrderExecutor(IOrderService orderService, IProductService productService, ICampaignService campaignService)
        {
            _orderService = orderService;
            _productService = productService;
            _campaignService = campaignService;
        }

        public async Task<BaseDto> Execute(BaseDto baseDto)
        {
            var dtoToExecute = (CreateOrderDto)baseDto;

            var campaign = await _campaignService.GetActiveCampaignForThisProduct(dtoToExecute.ProductCode);
            var product = await _productService.GetProductByCodeAsync(dtoToExecute.ProductCode);
            
            dtoToExecute.UnitPrice = product.Price;

            if (campaign !=null)
            {
                dtoToExecute.CampaignCode = campaign.Name;
                dtoToExecute.UnitPrice = campaign.ProductPrice;
            }

            await _orderService.CreateOrderAsync(dtoToExecute);

            await _productService.IncreaseStockAsync(dtoToExecute.ProductCode, dtoToExecute.Quantity);

            return dtoToExecute;
        }
    }
}
