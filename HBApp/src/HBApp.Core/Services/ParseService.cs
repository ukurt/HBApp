using HBApp.Core.Constant;
using HBApp.Core.Dto;
using HBApp.Core.Interfaces;
using HBApp.Core.ParseStrategy;
using System.Linq;
using System.Threading.Tasks;

namespace HBApp.Core.Services
{
    public class ParseService : IParseService
    {
        private StrategyContext strategyContext = new();
        public async Task<BaseDto> Parse(string text)
        {
            var splitted = text.Split(" ");
            if (splitted != null && splitted.Any())
            {
                var key = splitted[0];
                switch (key)
                {
                    case OperationContants.CreateProduct:
                        strategyContext.SetStrategy(new CreateProductParseStrategy());
                        break;
                    case OperationContants.CreateOrder:
                        strategyContext.SetStrategy(new CreateOrderParseStrategy());
                        break;
                    case OperationContants.CreateCampaign:
                        strategyContext.SetStrategy(new CreateCampaignParseStrategy());
                        break;
                    case OperationContants.GetCampaignInfo:
                        strategyContext.SetStrategy(new GetCampaignInfoParseStrategy());
                        break;
                    case OperationContants.GetProductInfo:
                        strategyContext.SetStrategy(new GetProductInfoParseStrategy());
                        break;
                    case OperationContants.IncreaseTime:
                        strategyContext.SetStrategy(new IncreaseTimeParseStrategy());
                        break;

                    default:
                        break;
                }

                return await strategyContext.Execute(text);
            }

            return null;
        }
    }
}
