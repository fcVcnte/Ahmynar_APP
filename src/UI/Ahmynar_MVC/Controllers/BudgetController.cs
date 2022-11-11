using Ahmynar_MVC.Contracts;
using Ahmynar_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ahmynar_MVC.Controllers
{
    public class BudgetController : Controller
    {
        private readonly IBudgetService _budgetServ;
        private readonly ICustomerService _customerServ;
        private readonly IProductService _productServ;
        private readonly IServiceService _serviceServ;

        public BudgetController(IBudgetService producServ, ICustomerService customerServ, IProductService productServ, IServiceService serviceServ)
        {
            this._budgetServ = producServ;
            this._customerServ = customerServ;
            this._productServ = productServ;
            this._serviceServ = serviceServ;
        }

        // GET: BudgetController
        public async Task<ActionResult> Index()
        {
            var budgets = await _budgetServ.GetBudgets();
            return View(budgets);
        }

        // GET: BudgetController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var budget = await _budgetServ.GetBudgetDetails(id);
            return View(budget);
        }

        // GET: BudgetController/Create
        public async Task<ActionResult> Create()
        {
            var customers = await _customerServ.GetCustomersList();
            var products = await _productServ.GetProducts();
            var services = await _serviceServ.GetServices();
            var customerItems = new SelectList(customers, "Id", "TradeName");
            var productItems = new SelectList(products, "Id", "Description");
            var serviceItems = new SelectList(services, "Id", "Description");
            var model = new CreateBudgetVM
            {
                Customers = customerItems,
                ProductsList = productItems,
                ServicesList = serviceItems
            };
            return View(model);
        }

        // POST: BudgetController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateBudgetVM budget)
        {
            try
            {
                var response = await _budgetServ.CreateBudget(budget);
                if (response.Success)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", response.ValidationErrors);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            var customers = await _customerServ.GetCustomers();
            var customerItems = new SelectList(customers, "Id", "TradeName");
            budget.Customers = customerItems;

            return View(budget);
        }

        // POST: BudgetController/Cancel/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Cancel(int id)
        {
            try
            {
                var response = await _budgetServ.CancelBudget(id);
                if (response.Success)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError("", response.ValidationErrors);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: BudgetController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var response = await _budgetServ.DeleteBudget(id);
                if (response.Success)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError("", response.ValidationErrors);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
