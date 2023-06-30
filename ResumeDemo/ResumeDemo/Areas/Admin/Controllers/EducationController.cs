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
public class EducationController : Controller
{
    private readonly IEducationService _educationService;
    private readonly Context _context;
    public EducationController(IEducationService educationService, Context context)
    {
        _educationService = educationService;
        _context = context;
    }

    public IActionResult Index()
    {
        var values = _educationService.GetList();
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
        var userMail = User.Identity.Name;
        var adminId = _context.Admins.Where(x => x.AdminMail == userMail).Select(y => y.AdminId).FirstOrDefault();
        EducationValidator av = new EducationValidator();
        ValidationResult results = av.Validate(e);
        if (results.IsValid)
        {
            e.EducationStatus = true;
            e.AdminId = adminId;
            _educationService.AddT(e);
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
        var values = _educationService.GetById(id);
        return View(values);
    }
    
    [HttpPost]
    public IActionResult EditEducation(Education e)
    {
        var userMail = User.Identity.Name;
        var adminId = _context.Admins.Where(x => x.AdminMail == userMail).Select(y => y.AdminId).FirstOrDefault();
        EducationValidator av = new EducationValidator();
        ValidationResult results = av.Validate(e);
        if (results.IsValid)
        {
            e.EducationStatus = true;
            e.AdminId = adminId;
            _educationService.UpdateT(e);
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
        var value = _educationService.GetById(id);
        _educationService.DeleteT(value);
        return RedirectToAction("Index","Education");
    }
}