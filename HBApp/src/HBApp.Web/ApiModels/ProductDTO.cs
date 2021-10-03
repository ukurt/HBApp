using System.Collections.Generic;

namespace HBApp.Web.ApiModels
{
    public class ProductDTO 
    {
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

    }
}

