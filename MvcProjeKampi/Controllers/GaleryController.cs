using Business.Concrete;
using DataAccsess.EntityFramework;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class GaleryController : Controller
    {
        ImageFileManager imageFileManager = new ImageFileManager(new EfImageFileDal());

        public ActionResult Index()
        {
            var result = imageFileManager.GetAll();
            return View(result);
        }
    }
}