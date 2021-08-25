using Sales.Domain.Products;
using SharedKernel;
using System;

namespace Sales.Domain.Customers.Orders
{
    public class OrderLine
    {
        private OrderLine()
        {
        }

        private OrderLine(
            ProductId productId,
            uint quantity,
            Money productPrice)
        {
            ProductId = productId;
            Quantity = quantity;
            ProductPrice = productPrice;
        }

        public ProductId ProductId { get; }
        public uint Quantity { get; }
        public Money ProductPrice { get; }

        internal static OrderLine Create(
            ProductId productId,
            Money productBasePrice,
            uint quantity,
            Currency currency,
            Func<Currency, Money, Money> currencyConverter)
        {
            var productPrice = CalculateProductPrice(productBasePrice, currency, currencyConverter);
            return new OrderLine(productId, quantity, productPrice);
        }

        private static Money CalculateProductPrice(Money basePrice, Currency currency, Func<Currency, Money, Money> currencyConverter)
        {
            return currencyConverter(currency, basePrice);
        }
    }
}