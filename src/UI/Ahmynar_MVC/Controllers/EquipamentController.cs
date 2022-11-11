using Ahmynar_MVC.Contracts;
using Ahmynar_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ahmynar_MVC.Controllers
{
    public class EquipamentController : Controller
    {
        private readonly IEquipamentService _equipamentServ;
        private readonly ICustomerService _customerServ;

        public EquipamentController(IEquipamentService producServ, ICustomerService customerServ)
        {
            this._equipamentServ = producServ;
            this._customerServ = customerServ;
        }

        // GET: EquipamentController
        public async Task<ActionResult> Index()
        {
            var equipaments = await _equipamentServ.GetEquipaments();
            return View(equipaments);
        }

        // GET: EquipamentController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var equipament = await _equipamentServ.GetEquipamentDetails(id);
            return View(equipament);
        }

        // GET: EquipamentController/Create
        public async Task<ActionResult> Create()
        {
            var customers = await _customerServ.GetCustomersList();
            var customerItems = new SelectList(customers, "Id", "TradeName");
            var model = new CreateEquipamentVM
            {
                Customers = customerItems
            };
            return View(model);
        }

        // POST: EquipamentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateEquipamentVM equipament)
        {
            try
            {
                var response = await _equipamentServ.CreateEquipament(equipament);
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

            var customers = await _customerServ.GetCustomersList();
            var customerItems = new SelectList(customers, "Id", "TradeName");
            equipament.Customers = customerItems;

            return View(equipament);
        }

        // GET: EquipamentController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var equipament = await _equipamentServ.GetEquipamentDetails(id);
            var customers = await _customerServ.GetCustomersList();
            var customerItems = new SelectList(customers, "Id", "TradeName");

            equipament.Customers = customerItems;

            return View(equipament);
        }

        // POST: EquipamentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EquipamentVM equipament)
        {
            try
            {
                var response = await _equipamentServ.UpdateEquipament(equipament);
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
            return View(equipament);
        }

        // POST: EquipamentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var response = await _equipamentServ.DeleteEquipament(id);
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
