using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace ResumeDemo.Areas.Resume.ViewComponents.About;

public class ShowAbout : ViewComponent
{
    AboutManager abm = new AboutManager(new EFAboutRepository());
    public IViewComponentResult Invoke()
    {
        var values = abm.GetAboutById(1);
        return View(values);
    }
}