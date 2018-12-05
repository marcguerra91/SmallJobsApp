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
    public class AssignedJobsController : Controller
    {
        // GET: AssignedJob
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AssignedJobService(userId);
            var model = service.GetAssignedJobs();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AssignedJobsCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateAssignedJobService();
            
            if (service.CreateAssignedJobs(model))
            {
                TempData["SaveResult"] = "Your assignment was created.";
            return RedirectToAction("Index");
            };

            return View(model);

        }

        private AssignedJobService CreateAssignedJobService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AssignedJobService(userId);
            return service;
        }
    }
}