using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBApp.Core.Dto
{
    public class CreateCampaignDto : BaseDto
    {
        public string Name { get; set; }
        public string ProductCode { get; set; }
        public int Duration { get; set; }
        public int PriceManipulationLimit { get; set; }
        public int TargetSaleCount { get; set; }

        public override string ToString()
        {
            return $"Campaign created; name {Name}, product {ProductCode}, duration {Duration},limit {PriceManipulationLimit}, target sales count {TargetSaleCount}";
        }

    }
}
