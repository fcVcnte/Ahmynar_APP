using Ahmynar_Application.Contracts.Persistence.Common;
using Ahmynar_Domain;

namespace Ahmynar_Application.Contracts.Persistence
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task AddQuantityAsync(Product product, int quantityIn);
        Task RemoveQuantityAsync(Product product, int quantityOut);
    }
}
