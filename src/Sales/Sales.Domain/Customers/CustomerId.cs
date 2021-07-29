using SharedKernel;
using System;

namespace Sales.Domain.Customers
{
    public class CustomerId : StronglyTypedId<Guid>
    {
        internal CustomerId(Guid value) : base(value)
        {
        }
    }
}