﻿using Business.Concrete;
using DataAccsess.EntityFramework;
using MvcProjeKampi.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class ScheduleController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        [HttpGet]
        public ActionResult Index()
        {
            return View(new Calender());
        }

        public JsonResult GetEvents(DateTime start, DateTime end)
        {
            var viewModel = new Calender();
            var events = new List<Calender>();
            start = DateTime.Today.AddDays(-14);
            end = DateTime.Today.AddDays(-14);

            foreach (var item in headingManager.GetAll())
            {
                events.Add(new Calender()
                {
                    title = item.HeadingName,
                    start = item.HeadingDate,
                    end = item.HeadingDate.AddDays(-14),
                    allDay = false
                });

                start = start.AddDays(7);
                end = end.AddDays(7);
            }
            return Json(events.ToArray(), JsonRequestBehavior.AllowGet);
        }
    }
}