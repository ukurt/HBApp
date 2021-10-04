using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBApp.Core.Dto
{
    public class CreateProductDto : BaseDto
    {
        public string ProductCode { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public override string ToString()
        {
            return $"Product created; code {ProductCode}, price {Price}, stock {Stock}";
        }

    }
}
