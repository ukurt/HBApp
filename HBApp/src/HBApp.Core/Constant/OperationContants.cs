using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBApp.Core.Constant
{
    public class OperationContants
    {
        public const string CreateProduct = "create_product";
        public const string GetProductInfo = "get_product_info";
        public const string CreateOrder = "create_order";
        public const string CreateCampaign = "create_campaign";
        public const string GetCampaignInfo = "get_campaign_info";
        public const string IncreaseTime = "increase_time";

        public const string Pattern = @"(?<whitespace>\s*)|" +
                @"(?<variable>[a-zA-Z_$][a-zA-Z0-9_$]*)|" +
                 @"(?<integer>[0-9]+)|" +
                @"(?<invalid>[^\s]+)";

        public const string CampaignStatusComplete = "Complete";
        public const string CampaignStatusActive = "Active";

    }
}
