using Entities.Concrete;
using System.Collections.Generic;

namespace MvcProjeKampi.ViewModels
{
    public class SkillVM
    {
        public List<Skill> Skills { get; set; }
        public Person Persons { get; set; }
    }
}