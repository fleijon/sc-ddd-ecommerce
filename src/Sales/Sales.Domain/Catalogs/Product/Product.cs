using System;

namespace Sales.Domain.Catalog.Product
{
    public class Product
    {
        private Product(string name)
        {
            Id = new ProductId(Guid.NewGuid());
            Name = name;
        }

        public static Product Create(string name)
        {
            return new Product(name);
        }

        public ProductId Id { get; }
        public string Name { get; }
    }
}