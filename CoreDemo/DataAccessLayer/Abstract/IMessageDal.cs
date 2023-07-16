using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract;

public interface IMessageDal : IGenericDal<Message>
{
    List<Message> GetListWithMessagesByAuthor(int id);
}