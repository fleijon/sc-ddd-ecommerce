using SharedKernel;
using System;

namespace Billing.Domain.Payments
{
    public class Payment : AggregateRoot<PaymentId>
    {
        private Payment()
        {
        }

        private Payment(OrderId orderId)
        {
            OrderId = orderId;
        }

        public OrderId OrderId { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? PaidAt { get; private set; }
        public PaymentStatus Status { get; private set; }

        public static Payment Create(OrderId orderId)
        {
            throw new NotImplementedException();
        }
    }
}