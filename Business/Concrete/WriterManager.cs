using Business.Abstract;
using DataAccsess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class WriterManager : IWriterService
    {
        private readonly IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public void Add(Writer writer)
        {
            _writerDal.Add(writer);
        }

        public void Delete(Writer writer)
        {
            _writerDal.Delete(writer);
        }

        public Writer Get(int id)
        {
            return _writerDal.Get(c => c.WriterId == id);
        }

        public List<Writer> GetAll()
        {
            return _writerDal.GetAll();
        }

        public void Update(Writer writer)
        {
            _writerDal.Update(writer);
        }
    }
}
