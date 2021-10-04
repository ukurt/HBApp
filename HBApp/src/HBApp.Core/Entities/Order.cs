using HBApp.Core.Constant;
using HBApp.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBApp.Core
{
    public class Order : BaseEntity
    {
        public string ProductCode { get; set; }
        public int Quantity { get; set; }
        public int Status { get; set; } = 1;
        public string CampaignCode { get; set; }
        public decimal UnitPrice { get; set; } = 1;
        public Order()
        {

        }
        public Order(string productCode, int quantity, string campaignCode, decimal unitPrice)
        {
            ProductCode = productCode;
            Quantity = quantity;
            CampaignCode = campaignCode;
            UnitPrice = unitPrice;
            Status = OperationContants.OrderStatusActive;
        }
    }
}
