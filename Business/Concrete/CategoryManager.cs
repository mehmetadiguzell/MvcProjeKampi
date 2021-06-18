using DataAccsess.Concrete.Repositories;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager
    {
        GenericRepository<Category> repository = new GenericRepository<Category>();
        public List<Category> GetAll()
        {
            return repository.GetAll();
        }

        public void Add(Category category)
        {
            if (category.CategoryName.Length>50)
            {
                return;
            }
            repository.Add(category);
        }
    }
}
