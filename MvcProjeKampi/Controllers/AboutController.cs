using Business.Concrete;
using DataAccsess.EntityFramework;
using Entities.Concrete;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AboutController : Controller
    {
        AboutManager aboutManager = new AboutManager(new EfAboutDal());

        public ActionResult Index()
        {
            var result = aboutManager.GetAll();
            return View(result);
        }

        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(About about)
        {
            aboutManager.Add(about);
            return RedirectToAction("Index");
        }
        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }
        public ActionResult Status(int id = 0)
        {
            var result = aboutManager.Get(id);
            if (result.Status == true)
            {
                result.Status = false;
            }
            else
            {
                result.Status = true;
            }
            aboutManager.Update(result);
            return RedirectToAction("Index");
        }
    }
}