using Ahmynar_MVC.Models;
using Ahmynar_MVC.Services.Base;

namespace Ahmynar_MVC.Contracts
{
    public interface ISaleService
    {
        Task<List<SaleVM>> GetSales();
        Task<SaleVM> GetSaleDetails(int id);
        Task<Response<int>> CreateSaleBudget(CreateSaleBudgetVM saleBudget);
        Task<Response<int>> CreateSaleProducts(CreateSaleProductsVM saleProducts);
        Task<Response<int>> DeleteSale(int id);
    }
}
