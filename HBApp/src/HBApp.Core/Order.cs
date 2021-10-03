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

        public Order()
        {

        }
        public Order(string productCode, int quantiy)
        {
            ProductCode = productCode;
            Quantity = quantiy;
        }
    }
}
