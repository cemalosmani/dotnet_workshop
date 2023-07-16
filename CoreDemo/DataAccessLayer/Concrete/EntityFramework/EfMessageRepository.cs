using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete.EntityFramework;

public class EfMessageRepository : GenericRepository<Message>, IMessageDal
{
    public List<Message> GetListWithMessagesByAuthor(int id)
    {
        using (var c = new Context())
        {
            return c.Messages.Include(x=>x.SenderUser).Where(x=>x.MessageReceiverId == id).ToList();
        }
    }
}