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
    public class BudgetRepository : GenericRepository<Budget>, IBudgetRepository
    {
        private readonly AhmynarDbContext _dbContext;

        public BudgetRepository(AhmynarDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public new async Task<IReadOnlyList<Budget>> GetAllAsync()
        {
            return await _dbContext.Set<Budget>().Include(b => b.Services).Include(b => b.Products).Include(b => b.Customer).ToListAsync();
        }
        public new async Task<Budget> GetByIdAsync(int id)
        {
            return await _dbContext.Set<Budget>().Include(b => b.Services).Include(b => b.Products).Include(b => b.Customer).FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task CancelBudgetAsync(Budget budget)
        {
            budget.Status = Ahmynar_Domain.Enums.StatusDescription.Canceled;
            _dbContext.Entry(budget).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
