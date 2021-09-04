using Paramore.Brighter;
using System;

namespace Sales.Application.Customers.PlaceOrder
{
    public class PlaceOrderCommand : ICommand
    {
        public Guid Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Guid CartId { get; private set; }
        public Guid CustomerId { get; private set; }
        public string Currency { get; private set; }

        public PlaceOrderCommand(Guid cartId, Guid customerId, string currency)
        {
            CartId = cartId;
            CustomerId = customerId;
            Currency = currency;
        }
    }
}