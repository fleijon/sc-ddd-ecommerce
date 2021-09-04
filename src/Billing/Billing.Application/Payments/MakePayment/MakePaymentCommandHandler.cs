using Billing.Domain;
using Billing.Domain.Payments;
using Paramore.Brighter;
using System.Threading;
using System.Threading.Tasks;

namespace Billing.Application.Payments.MakePayment
{
    public class MakePaymentCommandHandler : RequestHandlerAsync<MakePaymentCommand>
    {
        private readonly IBillingUnitOfWork _billingUnitOfWork;

        public MakePaymentCommandHandler(IBillingUnitOfWork billingUnitOfWork)
        {
            _billingUnitOfWork = billingUnitOfWork;
        }

        public async override Task<MakePaymentCommand> HandleAsync(MakePaymentCommand command, CancellationToken cancellationToken = default)
        {
            var payment = await _billingUnitOfWork.Payments.GetById(new PaymentId(command.PaymentId), cancellationToken);

            return command;
        }
    }
}