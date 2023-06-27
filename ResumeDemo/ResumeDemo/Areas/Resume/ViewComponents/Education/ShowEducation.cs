using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace ResumeDemo.Areas.Resume.ViewComponents.Education;

public class ShowEducation : ViewComponent
{
    EducationManager edm = new EducationManager(new EFEducationRepository());
    public IViewComponentResult Invoke()
    {
        var values = edm.GetList();
        return View(values);
    }
}