using Business.Concrete;
using Business.ValidationRules;
using DataAccsess.Concrete;
using DataAccsess.EntityFramework;
using Entities.Concrete;
using FluentValidation.Results;
using PagedList;
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
        WriterManager writerManager = new WriterManager(new EfWriterDal());

        Context context = new Context();

        public ActionResult WriterProfile(int id = 0)
        {
            string info = (string)Session["WriterMail"];
            id = context.Writers.Where(c => c.WriterMail == info).Select(y => y.WriterId).FirstOrDefault();
            var result = writerManager.Get(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult WriterProfile(Writer writer)
        {
            WriterValidator writerValidator = new WriterValidator();
            ValidationResult results = writerValidator.Validate(writer);
            if (results.IsValid)
            {
                writerManager.Update(writer);
                return RedirectToAction("AllHeading");
            }
            else
            {
                foreach (var result in results.Errors)
                {
                    ModelState.AddModelError(result.PropertyName, result.ErrorMessage);
                }
            }
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

        public ActionResult AllHeading(int page = 1)
        {
            var result = headingManager.GetAll().ToPagedList(page, 6);
            return View(result);
        }
    }
}