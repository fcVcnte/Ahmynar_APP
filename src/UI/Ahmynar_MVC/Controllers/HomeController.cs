using Ahmynar_MVC.Contracts;
using Ahmynar_MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Globalization;

namespace Ahmynar_MVC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IBudgetService _budgetServ;
        private readonly ISaleService _saleServ;
        private readonly IServiceOrderService _serviceOrderServ;

        public HomeController(IBudgetService budgetServ, ISaleService saleServ, IServiceOrderService serviceOrderServ)
        {
            _budgetServ = budgetServ;
            _saleServ = saleServ;
            _serviceOrderServ = serviceOrderServ;
        }

        public async Task<IActionResult> Index()
        {
            var budgets = await _budgetServ.GetBudgets();
            var sale = await _saleServ.GetSales();
            var serviceOrder = await _serviceOrderServ.GetServiceOrders();
            List<DashboardGraphVM> graphs = new();

            for (var date = DateTime.Now.AddMonths(-5); date.Date <= DateTime.Today; date = date.AddMonths(1)) {
                DashboardGraphVM graph = new()
                {
                    TotalBudgets = budgets.Where(x => x.DateCreated.Month == date.Month).Count(),
                    TotalSale = sale.Where(x => x.DateCreated.Month == date.Month).Count(),
                    TotalServiceOrder = serviceOrder.Where(x => x.DateCreated.Month == date.Month).Count(),
                    Month = date.ToString("MMM"),
                    Year = date.ToString("yyyy")
                };
                graphs.Add(graph);
            }

            DashboardVM dashboard = new()
            {
                Graphs = graphs,
                OpenBudgets = budgets.Count(x => x.Status == Ahmynar_Domain.Enums.StatusDescription.Open),
                OpenServiceOrders = serviceOrder.Count(x => x.Status == Ahmynar_Domain.Enums.StatusDescription.Open),
                SellBudgets = sale.Count(x => x.TypeSale == Ahmynar_Domain.Enums.TypeSale.BudgetSale),
                SellProducts = sale.Count(x => x.TypeSale == Ahmynar_Domain.Enums.TypeSale.ProductSale)
            };

            return View(dashboard);
        }

        public async Task<IActionResult> Budget()
        {
            return RedirectToAction("Create", "Budget");
        }

        public async Task<IActionResult> Customer()
        {
            return RedirectToAction("Create", "Customer");
        }

        public async Task<IActionResult> Sale()
        {
            return RedirectToAction("Create", "Sale");
        }

        public async Task<IActionResult> ServiceOrder()
        {
            return RedirectToAction("Create", "ServiceOrder");
        }
    }
}