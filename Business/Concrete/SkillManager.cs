using Business.Abstract;
using DataAccsess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class SkillManager : ISkillService
    {
        private readonly ISkillDal _skillDal;

        public SkillManager(ISkillDal skillDal)
        {
            _skillDal = skillDal;
        }

        public List<Skill> GetAll()
        {
            return _skillDal.GetAll();
        }
    }
}
