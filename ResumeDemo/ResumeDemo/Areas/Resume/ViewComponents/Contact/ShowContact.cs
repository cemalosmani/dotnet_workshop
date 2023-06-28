using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace ResumeDemo.Areas.Resume.ViewComponents.Contact;

public class ShowContact : ViewComponent
{
    private ContactManager cm = new ContactManager(new EFContactRepository());
    
    public IViewComponentResult Invoke()
    {
        var values = cm.GetList();
        return View(values);
    }
}