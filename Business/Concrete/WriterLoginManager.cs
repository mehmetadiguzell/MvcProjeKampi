using Business.Abstract;
using DataAccsess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class WriterLoginManager : IWriterLoginService
    {
        private readonly IWriterDal _writerDal;

        public WriterLoginManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public Writer GetWriter(string username, string password)
        {
            return _writerDal.Get(c => c.WriterMail == username && c.WriterPassword == password);
        }
    }
}
