using Business.Concrete;
using Business.ValidationRules;
using DataAccsess.Concrete;
using DataAccsess.EntityFramework;
using Entities.Concrete;
using FluentValidation.Results;
using System;
using System.Linq;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        [Obsolete]
        MessageValidator messageValidator = new MessageValidator();

        public ActionResult Inbox( )
        {
            string p= (string)Session["WriterMail"];           
            var result = messageManager.GetListInbox(p);
            return View(result);
        }

        public ActionResult Sendbox()
        {
            string p = (string)Session["WriterMail"];
            var result = messageManager.GetSendInbox(p);

            return View(result);
        }

        public ActionResult MessageDetails(int id)
        {
            var result = messageManager.Get(id);
            result.IsRead = true;
            messageManager.Update(result);
            return View(result);
        }

        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }

        public ActionResult NewMessage()
        {

            return View();
        }
        [HttpPost]
        [Obsolete]
        public ActionResult NewMessage(Message message)
        {

            ValidationResult results = messageValidator.Validate(message);
            if (results.IsValid)
            {
                message.SenderMail = (string)Session["WriterMail"];
                message.MessageDate = DateTime.Now;
                messageManager.Add(message);
                return RedirectToAction("Sendbox");
            }
            else
            {
                foreach (var result in results.Errors)
                {
                    ModelState.AddModelError(result.PropertyName, result.ErrorMessage);
                }
            }
            return View();
        }
    }
}