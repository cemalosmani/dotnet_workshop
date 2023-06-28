using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace ResumeDemo.Areas.Admin.Controllers;

[Area("Admin")]
public class EducationController : Controller
{
    private EducationManager edm = new EducationManager(new EFEducationRepository());
    
    public IActionResult Index()
    {
        var values = edm.GetList();
        ViewBag.ActivePage = "Education";
        return View(values);
    }
    
    [HttpGet]
    public IActionResult AddEducation()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult AddEducation(Education e)
    {
        EducationValidator av = new EducationValidator();
        ValidationResult results = av.Validate(e);
        if (results.IsValid)
        {
            e.EducationStatus = true;
            edm.AddT(e);
            return RedirectToAction("Index");
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
    public IActionResult EditEducation(int id)
    {
        var values = edm.GetById(id);
        return View(values);
    }
    
    [HttpPost]
    public IActionResult EditEducation(Education e)
    {
        EducationValidator av = new EducationValidator();
        ValidationResult results = av.Validate(e);
        if (results.IsValid)
        {
            e.EducationStatus = true;
            edm.UpdateT(e);
            return RedirectToAction("Index","Education");
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
    
    public IActionResult DeleteEducation(int id)
    {
        var value = edm.GetById(id);
        edm.DeleteT(value);
        return RedirectToAction("Index","Education");
    }
}