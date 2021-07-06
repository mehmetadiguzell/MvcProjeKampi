using Business.Concrete;
using DataAccsess.EntityFramework;
using Entities.Concrete;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{

    public class AuthorizationController : Controller
    {
        AdminManager adminManager = new AdminManager(new EfAdminDal());

        public ActionResult Index()
        {
            string name = (string)Session["AdminUserName"];
            var result = adminManager.Get(name);
            return View(result);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Admin admin)
        {
            adminManager.Add(admin);
            return RedirectToAction("Index");
        }

        public ActionResult Update(int id)
        {
            ViewBag.Roles = adminManager.GetRoles();
            var result = adminManager.Get(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult Update(Admin admin)
        {
            adminManager.Update(admin);
            return RedirectToAction("Index");
        }

        public ActionResult Status(int id)
        {
            var result = adminManager.Get(id);
            if (result.Status == true)
            {
                result.Status = false;
            }
            else
            {
                result.Status = true;
            }
            adminManager.Update(result);
            return RedirectToAction("Index");
        }
    }
}