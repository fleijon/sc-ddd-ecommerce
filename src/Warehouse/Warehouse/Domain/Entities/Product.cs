using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse.Domain.Entities
{
    public class Product
    {
        private readonly List<object> productOrders = new List<object>();

        public Guid Id { get; }

        public string Name { get; }

        public decimal Price { get; }

        public object Status { get; }

        public Guid ProductCategoryId { get; }

        public virtual IReadOnlyCollection<object> ProductOrders => productOrders;

        public Product()
        {
            // TODO: add parameters
        }

        // TODO: create set methods
    }
}