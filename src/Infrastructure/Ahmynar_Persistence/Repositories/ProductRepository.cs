using Ahmynar_Application.Contracts.Persistence;
using Ahmynar_Domain;
using Ahmynar_Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Persistence.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly AhmynarDbContext _dbContext;

        public ProductRepository(AhmynarDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public new async Task<IReadOnlyList<Product>> GetAllAsync()
        {
            return await _dbContext.Set<Product>().Include(p => p.Supplier).ToListAsync();
        }
        public new async Task<Product> GetByIdAsync(int id)
        {
            return await _dbContext.Set<Product>().Include(p => p.Supplier).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddQuantityAsync(Product product, int quantityIn)
        {
            product.Quantity = product.Quantity + quantityIn;
            _dbContext.Entry(product).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveQuantityAsync(Product product, int quantityOut)
        {
            product.Quantity = product.Quantity - quantityOut;
            _dbContext.Entry(product).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
