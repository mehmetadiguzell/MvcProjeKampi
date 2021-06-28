using Business.Concrete;
using DataAccsess.Concrete;
using DataAccsess.EntityFramework;
using Entities.Concrete;
using System;
using System.Linq;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelContentController : Controller
    {
        private readonly ContentManager contentManager = new ContentManager(new EfContentDal());
        private readonly Context context = new Context();

        public ActionResult MyContent(string mail)
        {
            mail = (string)Session["WriterMail"];
            var writerInfo = context.Writers.Where(c => c.WriterMail == mail).Select(y => y.WriterId).FirstOrDefault();
            var result = contentManager.GetListByWriter(writerInfo);
            return View(result);
        }
        public ActionResult AddContent(int id)
        {
            ViewBag.Id = id;
            return View();
        }

        [HttpPost]
        public ActionResult AddContent(Content content)
        {
            content.ContentDate = DateTime.Now;
            string mail = (string)Session["WriterMail"];
            var writerInfo = context.Writers.Where(c => c.WriterMail == mail).Select(y => y.WriterId).FirstOrDefault();
            content.WriterId = writerInfo;
            content.Status = true;
            contentManager.Add(content);
            return RedirectToAction("MyContent");
        }

        public ActionResult ToDoList()
        {

            return View();
        }
    }
}