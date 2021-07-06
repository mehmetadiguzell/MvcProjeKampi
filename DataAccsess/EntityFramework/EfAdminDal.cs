using DataAccsess.Abstract;
using DataAccsess.Concrete;
using DataAccsess.Concrete.Repositories;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace DataAccsess.EntityFramework
{
    public class EfAdminDal : GenericRepository<Admin>, IAdminDal
    {
        public List<SelectListItem> Roles()
        {
            using (Context context = new Context())
            {
                List<SelectListItem> result = (from x in context.AdminRoles.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.RoleName,
                                                   Value = x.RoleId.ToString()
                                               }).ToList();
                return result;
            }

        }
    }
}
