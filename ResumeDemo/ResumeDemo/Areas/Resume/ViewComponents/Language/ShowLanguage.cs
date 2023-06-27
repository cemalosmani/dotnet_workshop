using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace ResumeDemo.Areas.Resume.ViewComponents.Language;

public class ShowLanguage : ViewComponent
{
    LanguageManager lm = new LanguageManager(new EFLanguageRepository());

    public IViewComponentResult Invoke()
    {
        var values = lm.GetList();
        return View(values);
    }
}