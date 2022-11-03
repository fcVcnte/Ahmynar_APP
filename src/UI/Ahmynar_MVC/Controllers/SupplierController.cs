using Ahmynar_MVC.Contracts;
using Ahmynar_MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ahmynar_MVC.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ISupplierService _supplierServ;

        public SupplierController(ISupplierService supplierServ)
        {
            this._supplierServ = supplierServ;
        }

        // GET: SupplierController
        public async Task<ActionResult> Index()
        {
            var suppliers = await _supplierServ.GetSuppliers();
            return View(suppliers);
        }

        // GET: SupplierController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var supplier = await _supplierServ.GetSupplierDetails(id);
            return View(supplier);
        }

        // GET: SupplierController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SupplierController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateSupplierVM supplier)
        {
            try
            {
                var response = await _supplierServ.CreateSupplier(supplier);
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
            return View();
        }

        // GET: SupplierController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var supplier = await _supplierServ.GetSupplierDetails(id);
            return View(supplier);
        }

        // POST: SupplierController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(SupplierVM supplier)
        {
            try
            {
                var response = await _supplierServ.UpdateSupplier(supplier);
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
            return View(supplier);
        }

        // POST: SupplierController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var response = await _supplierServ.DeleteSupplier(id);
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
