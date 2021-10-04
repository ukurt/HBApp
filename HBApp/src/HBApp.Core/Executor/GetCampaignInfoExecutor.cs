using HBApp.Core.Dto;
using HBApp.Core.Interfaces;
using HBApp.Core.ParseStrategy;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HBApp.Core.Services
{
    public class GetCampaignInfoExecutor : IExecutor
    {
        ICampaignService _campaignService;
        IOrderService _orderService;
        public GetCampaignInfoExecutor(ICampaignService campaignService, IOrderService orderService)
        {
            _campaignService = campaignService;
            _orderService = orderService;
        }

        public async Task<BaseDto> Execute(BaseDto baseDto)
        {
            var dtoToExecute = (GetCampaignInfoDto)baseDto;
            dtoToExecute = await _campaignService.GetCampaignInfoAsync(dtoToExecute);

            return dtoToExecute;
        }
    }
}
