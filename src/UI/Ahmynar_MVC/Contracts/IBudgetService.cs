using Ahmynar_MVC.Models;
using Ahmynar_MVC.Services.Base;

namespace Ahmynar_MVC.Contracts
{
    public interface IBudgetService
    {
        Task<List<BudgetVM>> GetBudgets();
        Task<BudgetVM> GetBudgetDetails(int id);
        Task<Response<int>> CreateBudget(CreateBudgetVM budget);
        Task<Response<int>> DeleteBudget(int id);
    }
}
