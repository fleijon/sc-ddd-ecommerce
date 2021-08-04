using SharedKernel;
using System;

namespace Sales.Domain.Customers.Orders
{
    public class OrderId : StronglyTypedId<Guid>
    {
        internal OrderId(Guid id) : base(id)
        {
        }
    }
}