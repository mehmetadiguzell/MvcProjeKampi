using Entities.Concrete;

namespace Business.Abstract
{
    public interface ILoginService
    {
        Admin Login(Admin admin);
    }
}
