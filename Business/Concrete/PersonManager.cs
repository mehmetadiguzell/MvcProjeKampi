using Business.Abstract;
using DataAccsess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class PersonManager : IPersonService
    {
        private readonly IPersonDal _personDal;

        public PersonManager(IPersonDal personDal)
        {
            _personDal = personDal;
        }

        public Person Get()
        {
            return _personDal.Get(c => c.PersonId == 2);
        }
    }
}
