using Business.Concrete;
using DataAccsess.EntityFramework;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class DraftController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());

        public ActionResult Index()
        {
            var result = messageManager.GetAll();
            return View(result);
        }
    }
}