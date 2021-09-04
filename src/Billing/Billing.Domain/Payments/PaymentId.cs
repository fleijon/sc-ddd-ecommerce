using SharedKernel;
using System;

namespace Billing.Domain.Payments
{
    public class PaymentId : StronglyTypedId<Guid>
    {
        public PaymentId(Guid value) : base(value)
        {
        }
    }
}