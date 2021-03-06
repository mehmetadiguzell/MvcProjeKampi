using Business.Concrete;
using Business.ValidationRules;
using DataAccsess.EntityFramework;
using System.Linq;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContactController : Controller
    {
        ContactManager contactManager = new ContactManager(new EfContactDal());
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        ContactValidator rules = new ContactValidator();

        public ActionResult Index()
        {
            var result = contactManager.GetAll();
            var deger = result.Count();
            ViewBag.Total = deger;
            return View(result);
        }
        public ActionResult ContactDetails(int id)
        {
            var result = contactManager.Get(id);
            return View(result);
        }
        public PartialViewResult MessageMenu()
        {
            string mail = "admin@gmail.com";
            var total = contactManager.GetAll().Count();

            ViewBag.TotalInbox = messageManager.GetListInbox(mail).Count();
            ViewBag.TotalSendbox = messageManager.GetSendInbox(mail).Count();
            ViewBag.UnReadMessage = messageManager.UnIsRead();
            ViewBag.IsDraft = messageManager.IsDraft();
            ViewBag.Total = total;

            return PartialView();
        }
    }
}