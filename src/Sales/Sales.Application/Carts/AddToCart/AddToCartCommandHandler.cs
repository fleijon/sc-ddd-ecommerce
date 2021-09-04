using Ardalis.GuardClauses;
using Paramore.Brighter;
using Sales.Domain;
using Sales.Domain.Products;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sales.Application.Carts
{
    public class AddToCartCommandHandler : RequestHandler<AddToCartCommand>
    {
        private readonly ISalesUnitOfWork _salesUnitOfWork;

        public AddToCartCommandHandler(ISalesUnitOfWork salesUnitOfWork)
        {
            _salesUnitOfWork = salesUnitOfWork;
        }

        public async Task<Guid> Handle(AddToCartCommand request, CancellationToken cancellationToken)
        {
            var product = await _salesUnitOfWork.Products.GetProductById(new ProductId(request.ProductId), cancellationToken);

            // Could also get a cart by customer, and if null, create a new cart
            var cart = await _salesUnitOfWork.Carts.GetById(new Domain.Carts.CartId(request.CartId), cancellationToken);
            Guard.Against.Null(product, nameof(product));
            Guard.Against.Null(cart, nameof(cart));

            cart.AddItem(new ProductId(product.Id.Value), SharedKernel.Money.Of(product.Price.Value, request.Currency), request.Quantity);

            await _salesUnitOfWork.CommitAsync();

            return cart.Id.Value;
        }
    }
}