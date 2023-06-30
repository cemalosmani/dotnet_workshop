using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace ResumeDemo.Areas.Admin.Controllers;

[Area("Admin")]
public class SkillController : Controller
{
    private readonly ISkillService _skillService;
    private readonly Context _context;
    public SkillController(ISkillService skillService, Context context)
    {
        _skillService = skillService;
        _context = context;
    }

    public IActionResult Index()
    {
        var values = _skillService.GetList();
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
        var userMail = User.Identity.Name;
        var adminId = _context.Admins.Where(x => x.AdminMail == userMail).Select(y => y.AdminId).FirstOrDefault();
        SkillValidator av = new SkillValidator();
        ValidationResult results = av.Validate(s);
        if (results.IsValid)
        {
            s.SkillStatus = true;
            s.AdminId = adminId;
            _skillService.AddT(s);
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
        var values = _skillService.GetById(id);
        return View(values);
    }
    
    [HttpPost]
    public IActionResult EditSkill(Skill s)
    {
        var userMail = User.Identity.Name;
        var adminId = _context.Admins.Where(x => x.AdminMail == userMail).Select(y => y.AdminId).FirstOrDefault();
        SkillValidator av = new SkillValidator();
        ValidationResult results = av.Validate(s);
        if (results.IsValid)
        {
            s.SkillStatus = true;
            s.AdminId = adminId;
            _skillService.UpdateT(s);
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
        var value = _skillService.GetById(id);
        _skillService.DeleteT(value);
        return RedirectToAction("Index","Skill");
    }
}