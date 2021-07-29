﻿using System;
using System.Collections.Generic;
using System.Linq;
using Sales.Domain.Catalog.Product;
using Sales.Domain.Customers;

namespace Sales.Domain.Carts
{
    public class Cart
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
                throw new ArgumentNullException(nameof(customerId));
            }

            return new Cart(new CartId(Guid.NewGuid()), customerId);
        }

        private Dictionary<ProductId, CartItem> _cartItems = new Dictionary<ProductId, CartItem>();

        public void AddItem(ProductId productId, uint quantity)
        {
            if (productId is null)
            {
                throw new ArgumentNullException(nameof(productId));
            }
            if (_cartItems.ContainsKey(productId))
            {
                var item = _cartItems[productId];
                item.ChangeQuantityTo(item.Quantity + quantity);
            }
            else
            {
                _cartItems.Add(productId, new CartItem(productId, quantity));
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

        public CartId Id { get; }
        public CustomerId CustomerId { get; private set; }

        public IReadOnlyCollection<CartItem> CartItems => _cartItems.Select((kv) => kv.Value).ToList().AsReadOnly();
    }
}