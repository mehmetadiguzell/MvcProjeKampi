using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IHeadingService
    {
        List<Heading> GetAll();
        List<Heading> GetListByWriter(int id);
        Heading Get(int id);
        void Add(Heading heading);
        void Delete(Heading heading);
        void Update(Heading heading);
    }
}
