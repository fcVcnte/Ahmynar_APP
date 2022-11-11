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
    public class SaleRepository : GenericRepository<Sale>, ISaleRepository
    {
        private readonly AhmynarDbContext _dbContext;

        public SaleRepository(AhmynarDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public new async Task<IReadOnlyList<Sale>> GetAllAsync()
        {
            return await _dbContext.Set<Sale>().Include(s => s.Products).Include(s => s.Budget).ToListAsync();
        }
        public new async Task<Sale> GetByIdAsync(int id)
        {
            return await _dbContext.Set<Sale>().Include(s => s.Products).Include(s => s.Budget).FirstOrDefaultAsync(s => s.Id == id);
        }
    }
}
