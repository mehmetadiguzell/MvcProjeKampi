using Business.Abstract;
using DataAccsess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AdminManager : IAdminService
    {
        private readonly IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }
        public void Add(Admin admin)
        {
            _adminDal.Add(admin);
        }

        public void Delete(Admin admin)
        {
            _adminDal.Delete(admin);
        }

        public Admin Get(int id)
        {
            return _adminDal.Get(c => c.AdminId == id);
        }

        public List<Admin> GetAll()
        {
            return _adminDal.GetAll();
        }

        public void Update(Admin admin)
        {
            _adminDal.Update(admin);
        }
    }
}
