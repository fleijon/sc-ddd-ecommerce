using System;

namespace Sales.Domain.Customers
{
    public class Customer
    {
        private Customer(string name, CustomerId id)
        {
            Id = id;
            Name = name;
        }

        public static Customer Create(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException($"'{nameof(name)}' cannot be null or empty", nameof(name));
            }

            return new Customer(name, new CustomerId(Guid.NewGuid()));
        }

        public CustomerId Id { get; }
        public string Name { get; }
    }
}