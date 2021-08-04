using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Sales.Domain.Customers;
using FluentAssertions;
using SharedKernel;

namespace Sales.Domain.Tests.Unit.Customers
{
    public class CustomerTests
    {
        [Fact]
        public void Should_Be_Able_To_Create_Customer()
        {
            // arrange
            Func<string, bool> validator = (s) => true;
            // act
            var customer = Customer.Create("customer1", "customer1@email.com", validator);
            // assert
            customer.Should().NotBeNull();
        }

        [Fact]
        public void Should_Throw_BusinessException_When_Email_Is_Invalid()
        {
            // arrange
            Func<string, bool> validator = (s) => false;
            Action act = () => Customer.Create("customer1", "customer1@email.com", validator);
            // act
            act.Should().Throw<BusinessRuleException>();
            // assert
        }

        [Fact]
        public void Should_Be_Possible_To_Place_Order()
        {
            // arrange
            var product = Products.Product.Create("prod1");
            var price = Money.Of(new decimal(1.0), "Usd");
            var currency = new Currency("Usd", "$");

            Func<string, bool> validator = (s) => true;
            var customer = Customer.Create("customer1", "customer1@email.com", validator);
            var cart = Domain.Carts.Cart.Create(customer.Id);
            cart.AddItem(product.Id, price, 1);

            // act
            var order = customer.PlaceOrder(cart.CartItems.Select((ci) => ci), currency, null);

            // assert
            order.OrderLines.Length.Should().Be(1);
        }

        private static ConvertCurrency(Money price, Currency currency)
        {
            return price
        }
    }
}