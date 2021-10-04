using HBApp.Core.Dto;
using HBApp.Core.Interfaces;
using HBApp.Core.ParseStrategy;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HBApp.Core.Services
{
    public class CreateCampaignExecutor : IExecutor
    {
        ICampaignService _campaignService;
        public CreateCampaignExecutor(ICampaignService campaignService)
        {
            _campaignService = campaignService;
        }

        public async Task<BaseDto> Execute(BaseDto baseDto)
        {
            return null;
        }
    }
}
