﻿using DataAccsess.Abstract;
using DataAccsess.Concrete.Repositories;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsess.EntityFramework
{
    public class EfCategoryDal: GenericRepository<Category>,ICategoryDal
    {
    }
    
    
}