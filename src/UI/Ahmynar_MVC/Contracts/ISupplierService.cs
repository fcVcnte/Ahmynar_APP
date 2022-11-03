using Ahmynar_MVC.Models;
using Ahmynar_MVC.Services.Base;

namespace Ahmynar_MVC.Contracts
{
    public interface ISupplierService
    {
        Task<List<SupplierVM>> GetSuppliers();
        Task<SupplierVM> GetSupplierDetails(int id);
        Task<Response<int>> CreateSupplier(CreateSupplierVM supplier);
        Task<Response<int>> UpdateSupplier(SupplierVM supplier);
        Task<Response<int>> DeleteSupplier(int id);
    }
}
