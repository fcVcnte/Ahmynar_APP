using Ahmynar_MVC.Models;
using Ahmynar_MVC.Services.Base;

namespace Ahmynar_MVC.Contracts
{
    public interface IServiceOrderService
    {
        Task<List<ServiceOrderVM>> GetServiceOrders();
        Task<ServiceOrderVM> GetServiceOrderDetails(int id);
        Task<Response<int>> CreateServiceOrder(CreateServiceOrderVM serviceOrder);
        Task<Response<int>> UpdateServiceOrder(ServiceOrderVM serviceOrder);
        Task<Response<int>> DeleteServiceOrder(int id);
    }
}
