using Paramore.Brighter;
using System;

namespace Billing.Application.Payments.MakePayment
{
    public class MakePaymentCommand : ICommand
    {
        public Guid Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Guid PaymentId { get; set; }
    }
}