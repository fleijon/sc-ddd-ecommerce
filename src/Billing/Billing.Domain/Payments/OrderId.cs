using SharedKernel;
using System;

namespace Billing.Domain.Payments
{
    public class OrderId : StronglyTypedId<Guid>
    {
        public OrderId(Guid value) : base(value)
        {
        }
    }
}