﻿using eManager.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eManager.Web.Controllers
{
    public class ProteinTrackerController : Controller
    {
        private IProteinTrackingService proteinTrackingService;
            
            // GET: /ProteinTracker/

        public ProteinTrackerController(IProteinTrackingService proteinTrackingService)
        {
            this.proteinTrackingService = proteinTrackingService;
        }

        public ActionResult Index()
        {
            ViewBag.Total = proteinTrackingService.Total;
            ViewBag.Goal = proteinTrackingService.Goal;

            return View();
        }

        public ActionResult AddProtein(int amount)
        {
            proteinTrackingService.AddProtein(amount);

            ViewBag.Total = proteinTrackingService.Total;
            ViewBag.Goal = proteinTrackingService.Goal;

            return View("Index");
        }

    }
}
