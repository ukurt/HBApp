using HBApp.Core;

namespace HBApp.UnitTests
{
    //test kolaylığı için builder pattern
    public class ProductBuilder
    {
        private Product _product = new Product();

        public ProductBuilder Id(int id)
        {
            _product.Id = id;
            return this;
        }

        public ProductBuilder ProductCode(string pCode)
        {
            _product.ProductCode = pCode;
            return this;
        }

        public ProductBuilder Price(decimal price)
        {
            _product.Price = price;
            return this;
        }

        public ProductBuilder Stock(int stock)
        {
            _product.Stock = stock;
            return this;
        }

        public Product Build() => _product;
    }
}
