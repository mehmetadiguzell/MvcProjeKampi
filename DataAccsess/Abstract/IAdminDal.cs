using Entities.Concrete;
using System.Collections.Generic;
using System.Web.Mvc;

namespace DataAccsess.Abstract
{
    public interface IAdminDal : IRepository<Admin>
    {
        List<SelectListItem> Roles();
    }
}
