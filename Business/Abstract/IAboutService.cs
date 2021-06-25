using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IAboutService
    {
        List<About> GetAll();
        About Get(int id);
        void Add(About about);
        void Delete(About about);
        void Update(About about);
    }
}
