using System;
using System.Collections.Generic;
using System.Text;

namespace Shipping.Domain.Delivery
{
    internal class Delivery
    {
        public OrderId OrderId { get; }

        public DeliveryId DeliveryId { get; }

        public Address Address { get; }
    }
}