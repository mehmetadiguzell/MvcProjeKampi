using Business.Abstract;
using DataAccsess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class HeadingManager : IHeadingService
    {
        private readonly IHeadingDal _headingDal;

        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }

        public void Add(Heading heading)
        {
            _headingDal.Add(heading);
        }

        public void Delete(Heading heading)
        {
            _headingDal.Update(heading);
        }

        public Heading Get(int id)
        {
            return _headingDal.Get(c => c.HeadingId == id);
        }

        public List<Heading> GetAll()
        {
            return _headingDal.GetAll();
        }

        public List<Heading> GetListByWriter(int id)
        {
            return _headingDal.GetAll(c => c.WriterId == id);
        }

        public void Update(Heading heading)
        {
            _headingDal.Update(heading);
        }
    }
}
