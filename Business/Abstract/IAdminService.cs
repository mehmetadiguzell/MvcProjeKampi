using Entities.Concrete;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Business.Abstract
{
    public interface IAdminService
    {
        List<Admin> GetAll();
        Admin Get(int id);
        List<Admin> Get(string username);
        void Add(Admin admin);
        void Delete(Admin admin);
        void Update(Admin admin);
        List<SelectListItem> GetRoles();
    }
}
