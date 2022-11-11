using Ahmynar_Application.Contracts.Persistence.Common;
using Ahmynar_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Application.Contracts.Persistence
{
    public interface IBudgetRepository : IGenericRepository<Budget>
    {
        Task CancelBudgetAsync(Budget budget);
    }
}
