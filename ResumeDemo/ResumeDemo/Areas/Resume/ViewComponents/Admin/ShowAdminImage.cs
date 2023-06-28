using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ResumeDemo.Areas.Resume.ViewComponents.Admin;

public class ShowAdminImage : ViewComponent
{
    AdminManager adm = new AdminManager(new EFAdminRepository());

    public IViewComponentResult Invoke()
    {
        var values = adm.GetById(1);
        return View(values);
    }
}