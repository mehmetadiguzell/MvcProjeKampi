using DataAccsess.Concrete;
using System.Linq;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class IstatistikController : Controller
    {
        Context context = new Context();
        public ActionResult Index()
        {
            ViewBag.ToplamKategori = context.Categories.Count();

            var kategoriId = context.Categories.Where(c => c.CategoryName == "Yazılım").Select(y => y.CategoryId).FirstOrDefault();
            ViewBag.BaslikSayisi = context.Headings.Where(c => c.CategoryId == kategoriId).Select(m => m.HeadingName).Count();

            ViewBag.YazarSayisi = context.Writers.Where(c => c.WriterName.Contains("a")).Count();

            ViewBag.KategoriIsmi = context.Categories.Where(c => c.CategoryId == 6).Select(y => y.CategoryName).FirstOrDefault();
            //ViewBag.KategoriIsmi2 = context.Headings.Max(y => y.Category.CategoryName);


            int trueTotal = context.Categories.Where(c => c.CategoryStatus == true).Count();
            int falseTotal = context.Categories.Where(c => c.CategoryStatus == false).Count();
            ViewBag.KategoriDurumFark = trueTotal - falseTotal;

            return View();
        }
    }
}