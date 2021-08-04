using System;
using System.Collections.Generic;
using System.Linq;
using Sales.Domain.Products;
using Sales.Domain.Customers;
using SharedKernel;

namespace Sales.Domain.Carts
{
    public class Cart : AggregateRoot<CartId>
    {
        private Cart(CartId id, CustomerId customerId)
        {
            Id = id;
            CustomerId = customerId;
        }

        public static Cart Create(CustomerId customerId)
        {
            if (customerId is null)
            {
                throw new BusinessRuleException("A cart must be assigned a customer.");
            }

            return new Cart(new CartId(Guid.NewGuid()), customerId);
        }

        private Dictionary<ProductId, CartItem> _cartItems = new Dictionary<ProductId, CartItem>();

        public void AddItem(ProductId productId, Money productPrice, uint quantity)
        {
            if (productId is null)
            {
                throw new ArgumentNullException(nameof(productId));
            }

            if (productPrice is null)
            {
                throw new ArgumentNullException(nameof(productPrice));
            }

            if (_cartItems.ContainsKey(productId))
            {
                var item = _cartItems[productId];
                item.ChangeQuantityTo(item.Quantity + quantity);
            }
            else
            {
                _cartItems.Add(productId, new CartItem(productId, quantity, productPrice));
            }
        }

        public void RemoveItem(ProductId productId, uint quantity)
        {
            if (productId is null)
            {
                throw new ArgumentNullException(nameof(productId));
            }

            if (!_cartItems.ContainsKey(productId)) return;

            var cartItem = _cartItems[productId];

            if (cartItem.Quantity <= quantity)
            {
                _cartItems.Remove(productId);
            }
            else
            {
                var newQuantity = cartItem.Quantity - quantity;
                cartItem.ChangeQuantityTo(newQuantity);
            }
        }

        public void ClearAllCartItems()
        {
            _cartItems.Clear();
        }

        public CustomerId CustomerId { get; private set; }

        public IReadOnlyCollection<CartItem> CartItems => _cartItems.Select((kv) => kv.Value).ToList().AsReadOnly();
    }
}