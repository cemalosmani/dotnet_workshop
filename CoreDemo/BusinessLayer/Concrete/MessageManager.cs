using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class MessageManager : IMessageService
{
    IMessageDal _messageDal;

    public MessageManager(IMessageDal messageDal)
    {
        _messageDal = messageDal;
    }

    public void AddT(Message t)
    {
        _messageDal.Insert(t);
    }

    public void DeleteT(Message t)
    {
        _messageDal.Delete(t);
    }

    public void UpdateT(Message t)
    {
        _messageDal.Update(t);
    }

    public List<Message> GetList()
    {
        return _messageDal.GetListAll();
    }

    public Message GetById(int id)
    {
        return _messageDal.GetById(id);
    }

    public List<Message> GetInboxListByAuthor(int p)
    {
        return _messageDal.GetListWithMessagesByAuthor(p);
    }
}