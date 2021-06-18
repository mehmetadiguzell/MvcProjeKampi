using DataAccsess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsess.Concrete.Repositories
{
    public class CategoryRepository :GenericRepository<Category>,ICategoryDal
    {
        //Context context = new Context();
        //DbSet<Category> _dbSet;
        //public void Add(Category category)
        //{
        //    _dbSet.Add(category);
        //    context.SaveChanges();
        //}

        //public void Delete(Category entity)
        //{
        //    throw new NotImplementedException();
        //}

        //public List<Category> GetAll()
        //{
        //    throw new NotImplementedException();
        //}

        //public void Update(Category category)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
