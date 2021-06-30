using Business.Concrete;
using DataAccsess.Concrete;
using DataAccsess.EntityFramework;
using System.Linq;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContentController : Controller
    {
        private readonly ContentManager contentManager = new ContentManager(new EfContentDal());
        Context context = new Context();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllContent(string p)
        {
            if (string.IsNullOrEmpty(p))
            {
                var result = contentManager.GetAll();
                return View(result);
            }
            else
            {
                var result = contentManager.GetSearchList(p);
                return View(result);
            }  
        }

        public ActionResult ContentByHeading(int id = 0)
        {
            var result = contentManager.GetAll(id);
            return View(result);
        }
    }
}