using Ahmynar_MVC.Contracts;
using Ahmynar_MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ahmynar_MVC.Controllers
{
    [Authorize]
    public class SaleController : Controller
    {
        private readonly ISaleService _saleServ;
        private readonly IBudgetService _budgetServ;
        private readonly IProductService _productServ;

        public SaleController(ISaleService producServ, IBudgetService budgetServ, IProductService productServ)
        {
            this._saleServ = producServ;
            this._budgetServ = budgetServ;
            this._productServ = productServ;
        }

        // GET: SaleController
        public async Task<ActionResult> Index()
        {
            var sales = await _saleServ.GetSales();
            return View(sales);
        }

        // GET: SaleController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var sale = await _saleServ.GetSaleDetails(id);
            return View(sale);
        }

        // GET: SaleController/Create
        public async Task<ActionResult> Create()
        {
            var budgets = await _budgetServ.GetBudgets();
            var products = await _productServ.GetProducts();
            var budgetItems = new SelectList(budgets, "Id", "NumberTotal");
            var productItems = new SelectList(products, "Id", "DescSale");
            var model = new CreateSaleVM
            {
                Budgets = budgetItems,
                ProductsList = productItems
            };
            return View(model);
        }

        // POST: SaleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateSaleVM sale)
        {
            try
            {
                var response = await _saleServ.CreateSale(sale);
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

            var budgets = await _budgetServ.GetBudgets();
            var budgetItems = new SelectList(budgets, "Id", "NumberTotal");
            sale.Budgets = budgetItems;

            return View(sale);
        }
    }
}
