using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;

namespace DataAccessLayer.Concrete.EntityFramework;

public class EFSkillRepository : GenericRepository<Skill>, ISkillDal
{
}