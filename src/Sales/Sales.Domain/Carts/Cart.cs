using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Domain.Carts
{
    public class Cart
    {
        private List<CartItem> _cartItems = new List<CartItem>();

        public void AddItem(CartItem item)
        {
            _cartItems.Add(item);
        }

        public void RemoteItem(CartItem item)
        {
        }

        public IReadOnlyCollection<CartItem> CartItems => _cartItems;
    }
}