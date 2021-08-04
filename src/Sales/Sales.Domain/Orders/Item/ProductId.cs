using SharedKernel;
using System;

namespace Sales.Domain.Order.Item
{
    internal class ProductId : StronglyTypedId<Guid>
    {
        public ProductId(Guid value) : base(value)
        {
        }
    }
}