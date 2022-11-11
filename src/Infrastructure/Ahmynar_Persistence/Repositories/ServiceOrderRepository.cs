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
    public class ServiceOrderRepository : GenericRepository<ServiceOrder>, IServiceOrderRepository
    {
        private readonly AhmynarDbContext _dbContext;

        public ServiceOrderRepository(AhmynarDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public new async Task<IReadOnlyList<ServiceOrder>> GetAllAsync()
        {
            return await _dbContext.Set<ServiceOrder>().Include(so => so.Budget).ToListAsync();
        }
        public new async Task<ServiceOrder> GetByIdAsync(int id)
        {
            return await _dbContext.Set<ServiceOrder>().Include(so => so.Budget).FirstOrDefaultAsync(so => so.Id == id);
        }
    }
}
