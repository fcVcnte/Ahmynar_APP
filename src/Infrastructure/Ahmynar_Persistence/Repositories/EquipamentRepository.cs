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
    public class EquipamentRepository : GenericRepository<Equipament>, IEquipamentRepository
    {
        private readonly AhmynarDbContext _dbContext;

        public EquipamentRepository(AhmynarDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public new async Task<IReadOnlyList<Equipament>> GetAllAsync()
        {
            return await _dbContext.Set<Equipament>().Include(e => e.Customer).ToListAsync();
        }
        public new async Task<Equipament> GetByIdAsync(int id)
        {
            return await _dbContext.Set<Equipament>().Include(e => e.Customer).FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
