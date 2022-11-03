using Ahmynar_MVC.Models;
using Ahmynar_MVC.Services.Base;

namespace Ahmynar_MVC.Contracts
{
    public interface IEquipamentService
    {
        Task<List<EquipamentVM>> GetEquipaments();
        Task<EquipamentVM> GetEquipamentDetails(int id);
        Task<Response<int>> CreateEquipament(CreateEquipamentVM equipament);
        Task<Response<int>> UpdateEquipament(EquipamentVM equipament);
        Task<Response<int>> DeleteEquipament(int id);
    }
}
