using HBApp.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBApp.Core
{
    public class Product : BaseEntity
    {
        public string ProductCode { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public Product()
        {

        }
        public Product(string productCode, decimal price, int stock)
        {
            ProductCode = productCode;
            Price = price;
            Stock = stock;
        }

        public override string ToString()
        {
            return $"Product {ProductCode} info; price {Price}, stock {Stock}";
        }

    }
}
