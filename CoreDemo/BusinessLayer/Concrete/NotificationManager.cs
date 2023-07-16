using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class NotificationManager : INotificationService
{
    INotificationDal _notificationDal;

    public NotificationManager(INotificationDal notificationDal)
    {
        _notificationDal = notificationDal;
    }

    public void AddT(Notification t)
    {
        _notificationDal.Insert(t);
    }

    public void DeleteT(Notification t)
    {
        _notificationDal.Delete(t);
    }

    public void UpdateT(Notification t)
    {
        _notificationDal.Update(t);
    }

    public List<Notification> GetList()
    {
        return _notificationDal.GetListAll();
    }

    public Notification GetById(int id)
    {
        return _notificationDal.GetById(id);
    }
}