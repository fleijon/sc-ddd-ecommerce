using System;
using System.Collections.Generic;
using System.Linq;
using Sales.Domain.Customers.Orders;
using SharedKernel;

namespace Sales.Domain.Customers
{
    public class Customer : AggregateRoot<CustomerId>
    {
        private Customer(CustomerId id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }

        public static Customer Create(string name, string email, Func<string, bool> emailValidator)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException($"'{nameof(name)}' cannot be null or empty", nameof(name));
            }
            if (!emailValidator(email))
            {
                throw new BusinessRuleException("Email is invalid.");
            }

            return new Customer(new CustomerId(Guid.NewGuid()), name, email);
        }

        public Order PlaceOrder(IEnumerable<Carts.CartItem> items, Currency currency, Func<Currency, Money, Money> currencyConverter)
        {
            if (!items.Any())
            {
                throw new BusinessRuleException("An order must contain at least one item.");
            }
            if (currency == null)
            {
                throw new BusinessRuleException("No currency given.");
            }

            return Order.Create(
                new CustomerId(Id.Value),
                items,
                currency,
                currencyConverter);
        }

        public string Name { get; }
        public string Email { get; }
    }
}