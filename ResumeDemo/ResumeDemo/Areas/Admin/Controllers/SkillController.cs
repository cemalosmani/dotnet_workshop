using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace ResumeDemo.Areas.Admin.Controllers;

[Area("Admin")]
public class SkillController : Controller
{
    SkillManager sm = new SkillManager(new EFSkillRepository());
    
    public IActionResult Index()
    {
        var values = sm.GetList();
        ViewBag.ActivePage = "Skills";
        return View(values);
    }
    
    [HttpGet]
    public IActionResult AddSkill()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult AddSkill(Skill s)
    {
        SkillValidator av = new SkillValidator();
        ValidationResult results = av.Validate(s);
        if (results.IsValid)
        {
            s.SkillStatus = true;
            sm.AddT(s);
            return RedirectToAction("Index","Skill");
        }
        else
        {
            foreach (var item in results.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
        }
        return View();
    }
    
    [HttpGet]
    public IActionResult EditSkill(int id)
    {
        var values = sm.GetById(id);
        return View(values);
    }
    
    [HttpPost]
    public IActionResult EditSkill(Skill s)
    {
        SkillValidator av = new SkillValidator();
        ValidationResult results = av.Validate(s);
        if (results.IsValid)
        {
            s.SkillStatus = true;
            sm.UpdateT(s);
            return RedirectToAction("Index","Skill");
        }
        else
        {
            foreach (var item in results.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
        }
        return View();
    }
    
    public IActionResult DeleteSkill(int id)
    {
        var value = sm.GetById(id);
        sm.DeleteT(value);
        return RedirectToAction("Index","Skill");
    }
}