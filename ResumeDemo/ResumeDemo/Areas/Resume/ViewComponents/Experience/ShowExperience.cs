using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace ResumeDemo.Areas.Resume.ViewComponents.Experience;

public class ShowExperience : ViewComponent
{
    private ExperienceManager exm = new ExperienceManager(new EFExperienceRepository());
    public IViewComponentResult Invoke()
    {
        var values = exm.GetList();
        return View(values);
    }
}