using Business.Concrete;
using DataAccsess.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class HeadingController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());

        public ActionResult Index()
        {
            var result = headingManager.GetAll();
            return View(result);
        }
        public ActionResult Add()
        {

            List<SelectListItem> result = (from x in categoryManager.GetAll()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            List<SelectListItem> result2 = (from x in writerManager.GetAll()
                                            select new SelectListItem
                                            {
                                                Text = x.WriterName + " " + x.WriterSurName,
                                                Value = x.WriterId.ToString()
                                            }).ToList();
            ViewBag.CategoryList = result;
            ViewBag.WriterList = result2;
            return View();
        }
        [HttpPost]
        public ActionResult Add(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            headingManager.Add(heading);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            List<SelectListItem> result = (from x in categoryManager.GetAll()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.CategoryList = result;
            var model = headingManager.Get(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Heading heading)
        {
            headingManager.Update(heading);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var result = headingManager.Get(id);
            result.Status = false;
            headingManager.Delete(result);
            return RedirectToAction("Index");
        }
    }
}