﻿using DataAccsess.Abstract;
using DataAccsess.Concrete.Repositories;
using Entities.Concrete;

namespace DataAccsess.EntityFramework
{
    public class EfAboutDal : GenericRepository<About>, IAboutDal
    {
    }
}
