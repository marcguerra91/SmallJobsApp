using SmallJob.Models;
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
            var model = new JobsListItem[0];
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(JobCreate model)
        {
            if (ModelState.IsValid)
            {

            }

            return View(model);
        }
    }
}