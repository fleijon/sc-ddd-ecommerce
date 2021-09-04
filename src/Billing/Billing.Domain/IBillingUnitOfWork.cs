using Billing.Domain.Payments;

namespace Billing.Domain
{
    public interface IBillingUnitOfWork
    {
        public IPaymentRepository Payments { get; }
    }
}