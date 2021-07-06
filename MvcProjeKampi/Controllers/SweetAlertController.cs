using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class SweetAlertController : Controller
    {
        // GET: SweetAlert
        public ActionResult Index()
        {
            return View();
        }
    }
}