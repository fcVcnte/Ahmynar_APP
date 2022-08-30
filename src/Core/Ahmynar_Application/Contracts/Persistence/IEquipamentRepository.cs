using Ahmynar_Application.Contracts.Persistence.Common;
using Ahmynar_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Application.Contracts.Persistence
{
    public interface IEquipamentRepository : IGenericRepository<Equipament>
    {
        new Task<IReadOnlyList<Equipament>> GetAllAsync();
        new Task<Equipament> GetByIdAsync(int id);
    }
}
