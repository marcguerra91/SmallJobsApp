﻿using Microsoft.AspNet.Identity;
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
    public class SmallJobController : Controller
    {
        // GET: SmallJob
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new JobServices(userId);
            var model = service.GetJobs();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(JobCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateJobService();

            if (service.CreateJob(model))
            {
                TempData["SaveResult"] = "Your job has been added to the list!";
            return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Oh no, your job could not be created!");

            return View(model);

        }

        public ActionResult Details(int id)
        {
            var svc = CreateJobService();
            var model = svc.GetJobById(id);

            return View(model);
        }

        private JobServices CreateJobService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new JobServices(userId);
            return service;
        }
    }
}