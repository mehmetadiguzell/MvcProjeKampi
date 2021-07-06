using Business.Abstract;
using DataAccsess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class ContentManager : IContentServicecs
    {
        private readonly IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }

        public void Add(Content content)
        {
            _contentDal.Add(content);
        }

        public void Delete(Content content)
        {
            throw new NotImplementedException();
        }

        public Content Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Content> GetAll()
        {
            return _contentDal.GetAll();
        }

        public List<Content> GetAll(int id)
        {
            return _contentDal.GetAll(c => c.HeadingId == id);
        }

        public List<Content> GetListByWriter(int id)
        {
            return _contentDal.GetAll(c => c.WriterId == id);
        }

        public List<Content> GetSearchList(string p)
        {
            if (p != null)
            {
                return _contentDal.GetAll(c => c.ContentValue.Contains(p));
            }
            else
            {
                return _contentDal.GetAll();
            }


        }

        public void Update(Content content)
        {
            throw new NotImplementedException();
        }
    }
}
