using HBApp.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBApp.Core
{
    public class Campaign : BaseEntity
    {
        public string Name { get; set; }
        public string ProductCode { get; set; }
        public int Duration { get; set; }
        public int PriceManipulation { get; set; }
        public int TargetSaleCount { get; set; }
        public int Status { get; set; } // 1:Active 2:Complete

        public Campaign()
        {

        }
        public Campaign(string name, string productCode, int duration, int priceManipulation,int targetSaleCount)
        {
            Name = name;
            ProductCode = productCode;
            Duration = duration;
            PriceManipulation = priceManipulation;
            TargetSaleCount = targetSaleCount;
            Status = 1;
        }
    }
}
