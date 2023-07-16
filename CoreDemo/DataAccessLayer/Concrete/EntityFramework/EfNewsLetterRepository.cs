using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;

namespace DataAccessLayer.Concrete.EntityFramework;

public class EfNewsLetterRepository : GenericRepository<NewsLetter>, INewsLetterDal
{
    
}