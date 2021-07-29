using System;
using System.Collections.Generic;
using System.Text;
using SharedKernel;

namespace Sales.Domain.Catalog.Product
{
    public class ProductId : StronglyTypedId<Guid>
    {
        internal ProductId(Guid value) : base(value)
        {
        }
    }
}