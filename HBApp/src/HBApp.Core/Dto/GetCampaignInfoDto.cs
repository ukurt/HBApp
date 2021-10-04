using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBApp.Core.Dto
{
    public class GetCampaignInfoDto : BaseDto
    {
        public string Name { get; set; }
        public int Status { get; set; }
        public int TargetSales { get; set; }
        public int TotalSales { get; set; }
        public int Turnover { get; set; }
        public decimal AverageItemPrice{ get; set; }

        public override string ToString()
        {
            return $"Campaign {Name} info; Status {(Status == 1 ? "Active" : "Completed")}, Target Sales {TargetSales}, Total Sales {TotalSales}, Turnover {Turnover}, Average Item Price {AverageItemPrice}";
        }

    }
}
