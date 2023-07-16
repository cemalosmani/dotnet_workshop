using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers;

public class NewsLetterController : Controller
{
    NewsLetterManager nm = new NewsLetterManager(new EfNewsLetterRepository());
    [HttpGet]
    public PartialViewResult SubscribeMail()
    {
        return PartialView();
    }
    [HttpPost]
    public PartialViewResult SubscribeMail(NewsLetter n)
    {
        n.MailStatus = true;
        nm.AddNewsLetter(n);
        return PartialView();
    }
}