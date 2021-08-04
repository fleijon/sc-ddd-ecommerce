using System;
using SharedKernel;

namespace Sales.Domain.Products
{
    public class ProductId : StronglyTypedId<Guid>
    {
        internal ProductId(Guid value) : base(value)
        {
        }
    }
}