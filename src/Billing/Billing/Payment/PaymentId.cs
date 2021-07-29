using System;

namespace Billing.Payment
{
    internal class PaymentId : SharedKernel.StronglyTypedId<Guid>
    {
        public PaymentId(Guid value) : base(value)
        {
        }
    }
}