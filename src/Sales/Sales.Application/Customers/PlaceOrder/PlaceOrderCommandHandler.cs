using Ardalis.GuardClauses;
using Paramore.Brighter;
using Sales.Domain;
using Sales.Domain.Carts;
using Sales.Domain.Customers;
using System.Threading;
using System.Threading.Tasks;

namespace Sales.Application.Customers.PlaceOrder
{
    public class PlaceOrderCommandHandler : RequestHandlerAsync<PlaceOrderCommand>
    {
        private readonly ISalesUnitOfWork _salesUnitOfWork;
        private readonly ICurrencyConverter _currencyConverter;

        public PlaceOrderCommandHandler(ISalesUnitOfWork salesUnitOfWork,
            ICurrencyConverter currencyConverter)
        {
            _salesUnitOfWork = salesUnitOfWork;
            _currencyConverter = currencyConverter;
        }

        public override async Task<PlaceOrderCommand> HandleAsync(PlaceOrderCommand command, CancellationToken cancellationToken = default)
        {
            var cart = await _salesUnitOfWork.Carts.GetById(new CartId(command.CartId), cancellationToken);
            var customer = await _salesUnitOfWork.Customers.GetById(new CustomerId(command.CustomerId), cancellationToken);
            var currency = SharedKernel.Currency.FromCode(command.Currency);
            Guard.Against.Null(cart, nameof(cart));
            Guard.Against.Null(customer, nameof(customer));

            customer.PlaceOrder(cart.CartItems, currency, _currencyConverter);
            cart.ClearAllCartItems();

            await _salesUnitOfWork.CommitAsync();

            return command;
        }
    }
}