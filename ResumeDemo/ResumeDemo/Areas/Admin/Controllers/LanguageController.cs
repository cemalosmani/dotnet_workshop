using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace ResumeDemo.Areas.Admin.Controllers;

[Area("Admin")]
public class LanguageController : Controller
{
    LanguageManager lm = new LanguageManager(new EFLanguageRepository());
    
    public IActionResult Index()
    {
        var values = lm.GetList();
        ViewBag.ActivePage = "Languages";
        return View(values);
    }
    
    [HttpGet]
    public IActionResult AddLanguage()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult AddLanguage(Language l)
    {
        LanguageValidator av = new LanguageValidator();
        ValidationResult results = av.Validate(l);
        if (results.IsValid)
        {
            l.LanguageStatus = true;
            lm.AddT(l);
            return RedirectToAction("Index","Language");
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
    public IActionResult EditLanguage(int id)
    {
        var values = lm.GetById(id);
        return View(values);
    }
    
    [HttpPost]
    public IActionResult EditLanguage(Language l)
    {
        LanguageValidator av = new LanguageValidator();
        ValidationResult results = av.Validate(l);
        if (results.IsValid)
        {
            l.LanguageStatus = true;
            lm.UpdateT(l);
            return RedirectToAction("Index","Language");
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
    
    public IActionResult DeleteLanguage(int id)
    {
        var value = lm.GetById(id);
        lm.DeleteT(value);
        return RedirectToAction("Index","Language");
    }
}