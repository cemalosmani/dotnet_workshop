using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace ResumeDemo.Areas.Resume.ViewComponents.Admin;

public class ShowAdmin : ViewComponent
{
    AdminManager adm = new AdminManager(new EFAdminRepository());
        
    public IViewComponentResult Invoke()
    {
        var values = adm.GetById(1);
        return View(values);
    }
}