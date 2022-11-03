using Ahmynar_MVC.Models;
using Ahmynar_MVC.Services.Base;

namespace Ahmynar_MVC.Contracts
{
    public interface ICustomerService
    {
        Task<List<CustomerVM>> GetCustomers();
        Task<CustomerVM> GetCustomerDetails(int id);
        Task<Response<int>> CreateCustomer(CreateCustomerVM customer);
        Task<Response<int>> UpdateCustomer(CustomerVM customer);
        Task<Response<int>> DeleteCustomer(int id);
    }
}
