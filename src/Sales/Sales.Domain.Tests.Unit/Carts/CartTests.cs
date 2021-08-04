using Xunit;
using Sales.Domain.Carts;
using System.Linq;
using FluentAssertions;
using Sales.Domain.Products;
using Sales.Domain.Customers;
using System;

namespace Sales.Domain.Tests.Unit.Carts
{
    public class CartTests
    {
        [Fact]
        public void Should_Be_Possible_To_Add_Item_To_Cart()
        {
            // arrange
            Func<string, bool> validator = (str) => true;
            var customer = Customer.Create("customer1", "customer1@email.com", validator);
            var product = Product.Create("prod1");
            var cart = Cart.Create(customer.Id);

            // act
            cart.AddItem(product.Id, 1);

            // assert
            cart.CartItems.Count().Should().Be(1);
        }

        [Fact]
        public void Should_Be_Possible_To_Remove_Item_From_Cart()
        {
            // arrange
            Func<string, bool> validator = (str) => true;
            var customer = Customer.Create("customer1", "customer1@email.com", validator);
            var product = Product.Create("prod1");
            var cart = Cart.Create(customer.Id);

            cart.AddItem(product.Id, 1);

            // act
            cart.RemoveItem(product.Id, 1);

            // assert
            cart.CartItems.Count().Should().Be(0);
        }

        [Fact]
        public void Should_Be_Possible_To_Increase_Quantity_Of_Item()
        {
            // arrange
            Func<string, bool> validator = (str) => true;
            var customer = Customer.Create("customer1", "customer1@email.com", validator);
            var product = Product.Create("prod1");
            var cart = Cart.Create(customer.Id);

            // act
            cart.AddItem(product.Id, 1);
            cart.AddItem(product.Id, 1);

            // assert
            var item = cart.CartItems.Single((ci) => ci.ProductId == product.Id);
            item.Quantity.Should().Be(2);
        }

        [Fact]
        public void When_Quantity_Of_Item_Is_Below_Zero_It_Should_Be_Removed()
        {
            // arrange
            Func<string, bool> validator = (str) => true;
            var customer = Customer.Create("customer1", "customer1@email.com", validator);
            var product = Product.Create("prod1");
            var cart = Cart.Create(customer.Id);

            // act
            cart.AddItem(product.Id, 1);
            cart.RemoveItem(product.Id, 2);

            // assert
            var item = cart.CartItems.FirstOrDefault((ci) => ci.ProductId == product.Id);
            item.Should().BeNull();
        }

        [Fact]
        public void Should_Be_Possible_To_Decrease_Quantity_Of_Item()
        {
            // arrange
            Func<string, bool> validator = (str) => true;
            var customer = Customer.Create("customer1", "customer1@email.com", validator);
            var product = Product.Create("prod1");
            var cart = Cart.Create(customer.Id);

            // act
            cart.AddItem(product.Id, 3);
            cart.RemoveItem(product.Id, 2);

            // assert
            var item = cart.CartItems.Single((ci) => ci.ProductId == product.Id);
            item.Quantity.Should().Be(1);
        }

        [Fact]
        public void Should_Be_Possible_To_Clear_All_Items_From_Cart()
        {
            // arrange

            Func<string, bool> validator = (str) => true;
            var customer = Customer.Create("customer1", "customer1@email.com", validator);
            var product = Product.Create("prod1");
            var cart = Cart.Create(customer.Id);
            cart.AddItem(product.Id, 1);

            // act
            cart.ClearAllCartItems();

            // assert
            cart.CartItems.Count().Should().Be(0);
        }
    }
}