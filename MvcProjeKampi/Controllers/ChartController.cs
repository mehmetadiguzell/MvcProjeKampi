using DataAccsess.Concrete;
using MvcProjeKampi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{

    public class ChartController : Controller
    {
        //1
        public ActionResult Index()
        {
            return View();
        }
        public List<CategoryClass> BlogList()
        {
            List<CategoryClass> categoryClass = new List<CategoryClass>();
            categoryClass.Add(new CategoryClass()
            {
                CategoryName = "Yazılım",
                CategoryCount = 8
            });
            categoryClass.Add(new CategoryClass()
            {
                CategoryName = "Bilişim",
                CategoryCount = 3
            });
            categoryClass.Add(new CategoryClass()
            {
                CategoryName = "Spor",
                CategoryCount = 2
            });
            categoryClass.Add(new CategoryClass()
            {
                CategoryName = "PC Ürünler",
                CategoryCount = 3
            });

            return categoryClass;
        }

        public ActionResult CategoryChart()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);
        }


        //2

        public ActionResult Index2()
        {
            return View();
        }
        public List<CategoryHeadingChart> CategoryList()
        {
            List<CategoryHeadingChart> categoryClass = new List<CategoryHeadingChart>();
            using (Context context = new Context())
            {
                categoryClass = context.Categories.Select(x => new CategoryHeadingChart()
                {

                    CategoryName = x.CategoryName,
                    HeadingCount = x.Headings.Count
                }).ToList();
            }
            return categoryClass;
        }

        public ActionResult CategoryHeadingChart()
        {
            return Json(CategoryList(), JsonRequestBehavior.AllowGet);
        }

        //3
        public ActionResult Index3()
        {
            return View();
        }
        public List<WriterHeading> WriterHeadingList()
        {
            List<WriterHeading> writers = new List<WriterHeading>();
            using (Context context = new Context())
            {
                writers = context.Writers.Select(x => new WriterHeading()
                {
                    writerName = x.WriterName,
                    headingCount = x.Headings.Count
                }).ToList();
            }
            return writers;
        }

        public ActionResult WriterHeadingChart()
        {
            return Json(WriterHeadingList(), JsonRequestBehavior.AllowGet);
        }

    }
}