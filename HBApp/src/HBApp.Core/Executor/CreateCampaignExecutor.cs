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
        IProductService _productService;

        public CreateCampaignExecutor(ICampaignService campaignService, IProductService productService)
        {
            _campaignService = campaignService;
            _productService = productService;
        }

        public async Task<BaseDto> Execute(BaseDto baseDto)
        {
            var dtoToExecute = (CreateCampaignDto)baseDto;
            var existing = await _campaignService.GetCampaignAsync(dtoToExecute.Name);

            if (existing == null)
            {
                await _campaignService.AddCampaignAsync(dtoToExecute);
                Singleton.Instance.CampaignTill = DateTime.MinValue.AddHours(dtoToExecute.Duration);
            }
            
            return dtoToExecute;
        }
    }
}
