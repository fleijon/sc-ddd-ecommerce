using Ardalis.GuardClauses;
using Paramore.Brighter;
using Sales.Domain;
using Sales.Domain.Products;
using System.Threading;
using System.Threading.Tasks;

namespace Sales.Application.Carts
{
    public class AddToCartCommandHandler : RequestHandlerAsync<AddToCartCommand>
    {
        private readonly ISalesUnitOfWork _salesUnitOfWork;

        public AddToCartCommandHandler(ISalesUnitOfWork salesUnitOfWork)
        {
            _salesUnitOfWork = salesUnitOfWork;
        }

        public override async Task<AddToCartCommand> HandleAsync(AddToCartCommand command, CancellationToken cancellationToken = default)
        {
            var product = await _salesUnitOfWork.Products.GetProductById(new ProductId(command.ProductId), cancellationToken);

            // Could also get a cart by customer, and if null, create a new cart
            var cart = await _salesUnitOfWork.Carts.GetById(new Domain.Carts.CartId(command.CartId), cancellationToken);
            Guard.Against.Null(product, nameof(product));
            Guard.Against.Null(cart, nameof(cart));

            cart.AddItem(new ProductId(product.Id.Value), SharedKernel.Money.Of(product.Price.Value, command.Currency), command.Quantity);

            await _salesUnitOfWork.CommitAsync();
            return command;
        }
    }
}