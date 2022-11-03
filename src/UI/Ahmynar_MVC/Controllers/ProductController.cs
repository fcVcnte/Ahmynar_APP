using Ahmynar_MVC.Contracts;
using Ahmynar_MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ahmynar_MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _producServ;
        private readonly ISupplierService _supplierServ;

        public ProductController(IProductService producServ, ISupplierService supplierServ)
        {
            this._producServ = producServ;
            this._supplierServ = supplierServ;
        }

        // GET: ProductController
        public async Task<ActionResult> Index()
        {
            var products = await _producServ.GetProducts();
            return View(products);
        }

        // GET: ProductController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var product = await _producServ.GetProductDetails(id);
            return View(product);
        }

        // GET: ProductController/Create
        public async Task<ActionResult> Create()
        {
            var suppliers = await _supplierServ.GetSuppliers();
            var supplierItems = new SelectList(suppliers, "Id", "TradeName");
            var model = new CreateProductVM
            {
                Suppliers = supplierItems
            };
            return View(model);
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateProductVM product)
        {
            try
            {
                var response = await _producServ.CreateProduct(product);
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

            var suppliers = await _supplierServ.GetSuppliers();
            var supplierItems = new SelectList(suppliers, "Id", "TradeName");
            product.Suppliers = supplierItems;

            return View(product);
        }

        // GET: ProductController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var product = await _producServ.GetProductDetails(id);
            var suppliers = await _supplierServ.GetSuppliers();
            var supplierItems = new SelectList(suppliers, "Id", "TradeName");

            product.Suppliers = supplierItems;
            
            return View(product);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ProductVM product)
        {
            try
            {
                var response = await _producServ.UpdateProduct(product);
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
            return View(product);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var response = await _producServ.DeleteProduct(id);
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
