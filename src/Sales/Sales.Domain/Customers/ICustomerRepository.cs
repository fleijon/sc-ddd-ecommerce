using System.Threading;
using System.Threading.Tasks;

namespace Sales.Domain.Customers
{
    public interface ICustomerRepository
    {
        Task Add(Customer customer, CancellationToken cancellationToken);

        Task<Customer?> GetById(CustomerId customerId, CancellationToken cancellationToken);
    }
}