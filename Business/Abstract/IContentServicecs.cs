using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IContentServicecs
    {
        List<Content> GetAll();
        List<Content> GetAll(int id);
        Content Get(int id);
        void Add(Content content);
        void Delete(Content content);
        void Update(Content content);
    }
}
