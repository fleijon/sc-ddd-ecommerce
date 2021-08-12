using MediatR;
using System;

namespace Sales.Application.Carts.AddToCart
{
    public class AddToCartCommand : IRequest<Guid>
    {
        public Guid CustomerId { get; set; }
        public Guid ProductId { get; set; }
        public uint Quantity { get; set; }
        public string Currency { get; set; }
    }
}