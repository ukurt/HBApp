using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBApp.Core.Dto
{
    public class CreateOrderDto : BaseDto
    {
        public string ProductCode { get; set; }
        public int Quantity { get; set; }

        public override string ToString()
        {
            return $"Order created; product {ProductCode}, quantity {Quantity}";
        }

    }
}
