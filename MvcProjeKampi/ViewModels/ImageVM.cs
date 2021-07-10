using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProjeKampi.ViewModels
{
    public class ImageVM
    {
        public string ImageName { get; set; }
        public virtual HttpPostedFileBase GaleryImage { get; set; }
    }
}