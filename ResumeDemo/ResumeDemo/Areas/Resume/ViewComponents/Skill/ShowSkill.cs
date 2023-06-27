using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace ResumeDemo.Areas.Resume.ViewComponents.Skill;

public class ShowSkill : ViewComponent
{
    SkillManager sm = new SkillManager(new EFSkillRepository());

    public IViewComponentResult Invoke()
    {
        var values = sm.GetList();
        return View(values);
    }
}