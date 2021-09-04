using SharedKernel.Events;
using System;

namespace Sales.Contracts.Events
{
    public class OrderPlacedEvent : DomainEvent
    {
        public OrderPlacedEvent(Guid customerId, Guid orderId)
        {
            CustomerId = customerId;
            OrderId = orderId;
        }

        public Guid CustomerId { get; }
        public Guid OrderId { get; }
    }
}