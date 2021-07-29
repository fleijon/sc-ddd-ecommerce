using Xunit;
using Sales.Domain.Carts;
using System.Linq;
using FluentAssertions;

namespace Sales.Domain.Tests.Unit.Carts
{
    public class CartTests
    {
        [Fact]
        public void Should_Be_Possible_To_Add_Item_To_Cart()
        {
            // arrange
            var cart = new Cart();
            var product = new CartItem();

            // act
            cart.AddItem(product);

            // assert
            cart.CartItems.Count().Should().Be(1);
        }
    }
}