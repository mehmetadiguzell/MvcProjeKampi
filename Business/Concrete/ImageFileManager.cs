using Business.Abstract;
using DataAccsess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class ImageFileManager : IImageFileService
    {
        private readonly IImageFileDal _imageFileDal;

        public ImageFileManager(IImageFileDal imageFileDal)
        {
            _imageFileDal = imageFileDal;
        }
        public void Add(ImageFile imgFile)
        {
            _imageFileDal.Add(imgFile);
        }

        public List<ImageFile> GetAll()
        {
            return _imageFileDal.GetAll();
        }
    }
}
