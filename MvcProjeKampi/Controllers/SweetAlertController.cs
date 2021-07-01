using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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