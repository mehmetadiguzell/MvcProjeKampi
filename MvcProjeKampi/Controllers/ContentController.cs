using Business.Concrete;
using DataAccsess.EntityFramework;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContentController : Controller
    {
        private readonly ContentManager contentManager = new ContentManager(new EfContentDal());
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ContentByHeading(int id = 0)
        {
            var result = contentManager.GetAll(id);
            return View(result);
        }
    }
}