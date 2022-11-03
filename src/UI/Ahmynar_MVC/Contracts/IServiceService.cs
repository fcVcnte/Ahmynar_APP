using Ahmynar_MVC.Models;
using Ahmynar_MVC.Services.Base;

namespace Ahmynar_MVC.Contracts
{
    public interface IServiceService
    {
        Task<List<ServiceVM>> GetServices();
        Task<ServiceVM> GetServiceDetails(int id);
        Task<Response<int>> CreateService(CreateServiceVM service);
        Task<Response<int>> UpdateService(ServiceVM service);
        Task<Response<int>> DeleteService(int id);
    }
}
