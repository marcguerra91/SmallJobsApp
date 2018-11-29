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
            if (!ModelState.IsValid)
            {
            return View(model);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new WorkerService(userId);

            service.CreateWorker(model);

            return RedirectToAction("Index");
        }
    }
}