using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers;

public class AboutController : Controller
{
    AboutManager abm = new AboutManager(new EfAboutRepository());
    public IActionResult Index()
    {
        var values = abm.GetList();
        return View(values);
    }

    public PartialViewResult SocialMediaAbout()
    {
        return PartialView();
    }
}