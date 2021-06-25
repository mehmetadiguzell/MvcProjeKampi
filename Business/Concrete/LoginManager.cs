using Business.Abstract;
using DataAccsess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class LoginManager : ILoginService
    {
        private readonly IAdminDal _adminDal;

        public LoginManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public Admin Login(Admin admin)
        {
            return _adminDal.Get(x => x.AdminUserName == admin.AdminUserName && x.AdminPassword == admin.AdminPassword);
        }
    }
}
