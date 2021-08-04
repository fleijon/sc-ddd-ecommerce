using System;
using SharedKernel;

namespace Sales.Domain.Product
{
    public class ProductId : StronglyTypedId<Guid>
    {
        internal ProductId(Guid value) : base(value)
        {
        }
    }
}