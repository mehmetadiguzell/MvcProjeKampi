using MvcProjeKampi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
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
            return Json(BlogList(),JsonRequestBehavior.AllowGet);
        }
    }
}