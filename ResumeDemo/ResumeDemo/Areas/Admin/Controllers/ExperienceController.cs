using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace ResumeDemo.Areas.Admin.Controllers;

[Area("Admin")]
public class ExperienceController : Controller
{
    ExperienceManager exm = new ExperienceManager(new EFExperienceRepository());
    
    public IActionResult Index()
    {
        var values = exm.GetList();
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
        ExperienceValidator av = new ExperienceValidator();
        ValidationResult results = av.Validate(e);
        if (results.IsValid)
        {
            e.ExperienceStatus = true;
            exm.AddT(e);
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
        var values = exm.GetById(id);
        return View(values);
    }
    
    [HttpPost]
    public IActionResult EditExperience(Experience e)
    {
        ExperienceValidator av = new ExperienceValidator();
        ValidationResult results = av.Validate(e);
        if (results.IsValid)
        {
            e.ExperienceStatus = true;
            exm.UpdateT(e);
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
        var value = exm.GetById(id);
        exm.DeleteT(value);
        return RedirectToAction("Index","Experience");
    }
}