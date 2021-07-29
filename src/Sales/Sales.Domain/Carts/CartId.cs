using SharedKernel;
using System;

namespace Sales.Domain.Carts
{
    public class CartId : StronglyTypedId<Guid>
    {
        internal CartId(Guid value) : base(value)
        {
        }
    }
}