using Business.Concrete;
using DataAccsess.EntityFramework;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        private readonly ContentManager contentManager = new ContentManager(new EfContentDal());

        public ActionResult Headings()
        {
            var result = headingManager.GetAll();
            return View(result);
        }

        public ActionResult Index(int id = 0)
        {
            var result = contentManager.GetAll(id);
            return PartialView(result);
        }

        [AllowAnonymous]
        public ActionResult HomePage()
        {

            return View();
        }
    }
}