using Business.Concrete;
using DataAccsess.EntityFramework;
using MvcProjeKampi.ViewModels;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class SkillController : Controller
    {
        PersonManager personManager = new PersonManager(new EfPersonDal());
        SkillManager skillManager = new SkillManager(new EfSkillDal());

        public ActionResult Index()
        {
            SkillVM viewModel = new SkillVM
            {
                Skills = skillManager.GetAll(),
                Persons = personManager.Get()
            };
            return View(viewModel);
        }
    }
}