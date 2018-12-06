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

        public ActionResult Details(int id)
        {
            var svc = CreateAssignedJobService();
            var model = svc.GetAssignedJobById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateAssignedJobService();
            var detail = service.GetAssignedJobById(id);
            var model =
                new AssignedJobEdit
                {
                    AssignmentId = detail.AssignmentId,
                    JobId = detail.JobId,
                    TitleOfJob = detail.TitleOfJob,
                    WorkerId = detail.WorkerId,
                    JobComplete = detail.JobComplete,

                };

            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateAssignedJobService();
            var model = svc.GetAssignedJobById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateAssignedJobService();

            service.DeleteAssignedJob(id);

            TempData["SaveResult"] = "Your assignment was delete";

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AssignedJobEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.AssignmentId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateAssignedJobService();

            if (service.UpdateAssignedJob(model))
            {
                TempData["SaveResult"] = "Your assignment was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your assignment could not be updated.");
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