using Paramore.Brighter;
using System;

namespace Sales.Application.Carts
{
    public class AddToCartCommand : ICommand
    {
        public Guid CartId { get; set; }
        public Guid ProductId { get; set; }
        public uint Quantity { get; set; }
        public string Currency { get; set; }
        public Guid Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}