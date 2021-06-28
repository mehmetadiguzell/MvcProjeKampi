using Business.Concrete;
using DataAccsess.Concrete;
using DataAccsess.EntityFramework;
using Entities.Concrete;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly LoginManager loginManager = new LoginManager(new EfAdminDal());

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            var result = loginManager.Login(admin);

            if (result != null)
            {
                FormsAuthentication.SetAuthCookie(result.AdminUserName, false);
                Session["AdminUserName"] = result.AdminUserName;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                ViewBag.Error = "Kullanıcı adı veya şifre yanlış";
                return View();
            }

        }
        public ActionResult WriterLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterLogin(Writer writer)
        {
            using (Context context = new Context())
            {
                var result = context.Writers.FirstOrDefault(c => c.WriterMail == writer.WriterMail && c.WriterPassword == writer.WriterPassword);
                if (result != null)
                {
                    FormsAuthentication.SetAuthCookie(result.WriterMail, false);
                    Session["WriterMail"] = result.WriterMail;
                    return RedirectToAction("MyContent", "WriterPanelContent");
                }
                else
                {
                    ViewBag.Error = "Kullanıcı adı veya şifre yanlış";
                    return View();
                }
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return View("Headings", "Home");
        }
    }
}