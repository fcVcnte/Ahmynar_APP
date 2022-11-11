using Ahmynar_MVC.Contracts;
using Ahmynar_MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ahmynar_MVC.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IServiceService _serviceServ;

        public ServiceController(IServiceService serviceServ)
        {
            this._serviceServ = serviceServ;
        }

        // GET: ServiceController
        public async Task<ActionResult> Index()
        {
            var services = await _serviceServ.GetServices();
            return View(services);
        }

        // GET: ServiceController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var service = await _serviceServ.GetServiceDetails(id);
            return View(service);
        }

        // GET: ServiceController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ServiceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateServiceVM service)
        {
            try
            {
                var response = await _serviceServ.CreateService(service);
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

        // GET: ServiceController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var service = await _serviceServ.GetServiceDetails(id);
            return View(service);
        }

        // POST: ServiceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ServiceVM service)
        {
            try
            {
                var response = await _serviceServ.UpdateService(service);
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
            return View(service);
        }

        // POST: ServiceController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var response = await _serviceServ.DeleteService(id);
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
