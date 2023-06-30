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
public class ExperienceController : Controller
{
    private readonly IExperienceService _experienceService;
    private readonly Context _context;
    public ExperienceController(IExperienceService experienceService, Context context)
    {
        _experienceService = experienceService;
        _context = context;
    }

    public IActionResult Index()
    {
        var values = _experienceService.GetList();
        ViewBag.ActivePage = "Experience";
        return View(values);
    }
    
    [HttpGet]
    public IActionResult AddExperience()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult AddExperience(Experience e)
    {
        var userMail = User.Identity.Name;
        var adminId = _context.Admins.Where(x => x.AdminMail == userMail).Select(y => y.AdminId).FirstOrDefault();
        ExperienceValidator av = new ExperienceValidator();
        ValidationResult results = av.Validate(e);
        if (results.IsValid)
        {
            e.ExperienceStatus = true;
            e.AdminId = adminId;
            _experienceService.AddT(e);
            return RedirectToAction("Index","Experience");
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
    public IActionResult EditExperience(int id)
    {
        var values = _experienceService.GetById(id);
        return View(values);
    }
    
    [HttpPost]
    public IActionResult EditExperience(Experience e)
    {
        var userMail = User.Identity.Name;
        var adminId = _context.Admins.Where(x => x.AdminMail == userMail).Select(y => y.AdminId).FirstOrDefault();
        ExperienceValidator av = new ExperienceValidator();
        ValidationResult results = av.Validate(e);
        if (results.IsValid)
        {
            e.ExperienceStatus = true;
            e.AdminId = adminId;
            _experienceService.UpdateT(e);
            return RedirectToAction("Index","Experience");
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
    
    public IActionResult DeleteExperience(int id)
    {
        var value = _experienceService.GetById(id);
        _experienceService.DeleteT(value);
        return RedirectToAction("Index","Experience");
    }
}