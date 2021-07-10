using Business.Concrete;
using DataAccsess.Concrete;
using DataAccsess.EntityFramework;
using Entities.Concrete;
using MvcProjeKampi.ViewModels;
using System.IO;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    
    public class GaleryController : Controller
    {
        ImageFileManager imageFileManager = new ImageFileManager(new EfImageFileDal());

        public ActionResult Index()
        {
            var result = imageFileManager.GetAll();
            return View(result);
        }

        public ActionResult AddImage()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddImage(ImageVM imageVM)
        {

            string fotoAdi = Seo.DosyaAdiDuzenle(imageVM.GaleryImage.FileName);
            imageVM.ImageName = fotoAdi;
            ImageFile file = new ImageFile
            {
                ImageName = imageVM.ImageName,
                ImagePath= "/Admin/img/"+ imageVM.ImageName
            };
            imageFileManager.Add(file);
            imageVM.GaleryImage.SaveAs(Path.Combine(Server.MapPath("~/Admin/img/"), Path.GetFileName(fotoAdi)));
            TempData["mesaj"] = "Resim Eklendi";


            return RedirectToAction("Index");
        }
    }
}