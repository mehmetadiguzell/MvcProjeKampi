using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ISkillService
    {
        List<Skill> GetAll();
    }
}
