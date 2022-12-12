using Ahmynar_MVC.Contracts;
using Ahmynar_MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ahmynar_MVC.Controllers
{
    [Authorize]
    public class ServiceOrderController : Controller
    {
        private readonly IServiceOrderService _serviceOrderServ;
        private readonly IBudgetService _budgetServ;

        public ServiceOrderController(IServiceOrderService producServ, IBudgetService budgetServ)
        {
            this._serviceOrderServ = producServ;
            this._budgetServ = budgetServ;
        }

        // GET: ServiceOrderController
        public async Task<ActionResult> Index()
        {
            var serviceOrders = await _serviceOrderServ.GetServiceOrders();
            return View(serviceOrders);
        }

        // GET: ServiceOrderController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var serviceOrder = await _serviceOrderServ.GetServiceOrderDetails(id);
            return View(serviceOrder);
        }

        // GET: ServiceOrderController/Create
        public async Task<ActionResult> Create()
        {
            var budgets = await _budgetServ.GetBudgets();
            var budgetItems = new SelectList(budgets.Where(x => x.Status == Ahmynar_Domain.Enums.StatusDescription.Open), "Id", "NumberTotal");
            var model = new CreateServiceOrderVM
            {
                Budgets = budgetItems
            };
            return View(model);
        }

        // POST: ServiceOrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateServiceOrderVM serviceOrder)
        {
            try
            {
                var response = await _serviceOrderServ.CreateServiceOrder(serviceOrder);
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
            serviceOrder.Budgets = budgetItems;

            return View(serviceOrder);
        }

        // GET: ServiceOrderController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var serviceOrder = await _serviceOrderServ.GetServiceOrderDetails(id);
            var budgets = await _budgetServ.GetBudgets();
            var budgetItems = new SelectList(budgets, "Id", "NumberTotal");

            serviceOrder.Budgets = budgetItems;

            return View(serviceOrder);
        }

        // POST: ServiceOrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ServiceOrderVM serviceOrder)
        {
            try
            {
                var response = await _serviceOrderServ.UpdateServiceOrder(serviceOrder);
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
            return View(serviceOrder);
        }

        // POST: ServiceOrderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var response = await _serviceOrderServ.DeleteServiceOrder(id);
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
