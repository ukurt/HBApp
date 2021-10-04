using HBApp.Core.Dto;
using HBApp.Core.Interfaces;
using HBApp.Core.ParseStrategy;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HBApp.Core.Services
{
    public class IncreaseTimeExecutor : IExecutor
    {
        ICampaignService _campaignService;
        IOrderService _orderService;

        public IncreaseTimeExecutor(ICampaignService campaignService, IOrderService orderService)
        {
            _campaignService = campaignService;
            _orderService = orderService;
        }

        public async Task<BaseDto> Execute(BaseDto baseDto)
        {
            var campaigns = _campaignService.GetActiveCampaigns();

            foreach (var campaign in campaigns)
            {
                var totalSales = _orderService.GetTotalSales(campaign.Name);

                if (campaign.TargetSaleCount > totalSales)
                {
                    campaign.ProductPrice -= campaign.PriceManipulation;
                }
                else
                {
                    campaign.ProductPrice += campaign.PriceManipulation;
                }

                await _campaignService.UpdateCampaingAsync(campaign);
            }

            return (IncreaseTimeDto)baseDto;
        }
    }
}
