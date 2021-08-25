using System.Threading;
using System.Threading.Tasks;

namespace Sales.Domain.Products
{
    public interface IProductRepository
    {
        Task Add(Product product, CancellationToken cancellationToken);

        Task<Product?> GetProductById(ProductId productId, CancellationToken cancellationToken);
    }
}