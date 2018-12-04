using Microsoft.AspNet.Identity;
using SmallJob.Models;
using SmallJob.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmallJobsApp_BlueBadge.Controllers
{
    [Authorize]
    public class WorkerController : Controller
    {
        // GET: Worker
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new WorkerService(userId);
            var model = service.GetWorkers();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WorkerCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateWorkerService();

            if (service.CreateWorker(model))
            {
                TempData["SaveResult"] = "Worker has been added.";
            return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Worker could not be created.");

        return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateWorkerService();
            var model = svc.GetWorkerById(id);

            return View(model);
        }

        private WorkerService CreateWorkerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new WorkerService(userId);
            return service;
        }
    }
}