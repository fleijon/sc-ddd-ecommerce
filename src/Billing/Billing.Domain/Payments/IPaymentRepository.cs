using System.Threading;
using System.Threading.Tasks;

namespace Billing.Domain.Payments
{
    public interface IPaymentRepository
    {
        public Task<Payment> GetById(PaymentId paymentId, CancellationToken cancellationToken = default);
    }
}