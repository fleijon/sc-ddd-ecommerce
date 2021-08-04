using System;

namespace Sales.Domain.Product
{
    public class Product
    {
        private Product(string name, ProductId id)
        {
            Id = id;
            Name = name;
        }

        public static Product Create(string name)
        {
            var prodId = new ProductId(Guid.NewGuid());
            return new Product(name, prodId);
        }

        public void AddDescription(string description)
        {
            Description = new Description(description);
        }

        public ProductId Id { get; }
        public string Name { get; }

        public Description Description { get; private set; }
    }
}