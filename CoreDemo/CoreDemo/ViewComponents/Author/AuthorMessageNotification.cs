using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Author;

public class AuthorMessageNotification : ViewComponent
{
    MessageManager m2m = new MessageManager(new EfMessageRepository());
    public IViewComponentResult Invoke()
    {
        int p = 1;
        var values = m2m.GetInboxListByAuthor(p);
        return View(values);
    }
}