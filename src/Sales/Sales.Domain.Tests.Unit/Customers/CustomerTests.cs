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
    }
}