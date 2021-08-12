using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sales.Application.Carts.AddToCart
{
    public class AddToCartCommandHandler : IRequestHandler<AddToCartCommand, Guid>
    {
        public Task<Guid> Handle(AddToCartCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}