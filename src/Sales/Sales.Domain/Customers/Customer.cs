using Sales.Domain.Customers.Orders;
using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sales.Domain.Customers
{
    public class Customer : AggregateRoot<CustomerId>
    {
        private Customer()
        {
        }

        public Name Name { get; }
        public Email Email { get; }

        private Customer(CustomerId id, Name name, Email email)
        {
            Id = id;
            Name = name;
            Email = email;
        }

        public static Customer Of(
            CustomerId customerId,
            Name name,
            Email email
            )
        {
            return new Customer(customerId, name, email);
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

            return new Customer(CustomerId.Of(Guid.NewGuid()), Name.CreateNew(name, ""), Email.CreateNew(email));
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
    }
}