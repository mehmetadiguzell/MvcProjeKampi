using Business.Concrete;
using DataAccsess.Concrete;
using DataAccsess.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

        Context context = new Context();
        public ActionResult WriterProfile()
        {
            return View();
        }

        public ActionResult MyHeading(string info)
        {

            info = (string)Session["WriterMail"];
            var writerIdInfo = context.Writers.Where(c => c.WriterMail == info).Select(y => y.WriterId).FirstOrDefault();
            var result = headingManager.GetListByWriter(writerIdInfo);
            return View(result);

        }

        public ActionResult NewHeading()
        {

            List<SelectListItem> result = (from x in categoryManager.GetAll()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.CategoryList = result;
            return View();
        }
        [HttpPost]
        public ActionResult NewHeading(Heading heading)
        {
            string writerMailInfo = (string)Session["WriterMail"];
            var writerIdInfo = context.Writers.Where(c => c.WriterMail == writerMailInfo).Select(y => y.WriterId).FirstOrDefault();
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.WriterId = writerIdInfo;
            heading.Status = true;
            headingManager.Add(heading);
            return RedirectToAction("MyHeading");
        }

        public ActionResult Edit(int id = 0)
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
            return RedirectToAction("MyHeading");
        }
        public ActionResult Delete(int id)
        {
            var result = headingManager.Get(id);
            result.Status = false;
            headingManager.Delete(result);
            return RedirectToAction("MyHeading");
        }

        public ActionResult AllHeading()
        {
            var result = headingManager.GetAll();
            return View(result);
        }
    }
}