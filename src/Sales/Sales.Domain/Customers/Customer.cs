using Sales.Contracts.Events;
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

        private static Customer Of(
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

        public Order PlaceOrder(IEnumerable<Carts.CartItem> items, Currency currency, ICurrencyConverter currencyConverter)
        {
            if (!items.Any())
            {
                throw new BusinessRuleException("An order must contain at least one item.");
            }
            if (currency == null)
            {
                throw new BusinessRuleException("No currency given.");
            }

            var order = Order.Create(
                Id,
                items,
                currency,
                currencyConverter);

            AddDomainEvent(new OrderPlacedEvent(Id.Value, order.Id.Value));

            return order;
        }
    }
}