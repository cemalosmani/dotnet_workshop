using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace ResumeDemo.Areas.Admin.Controllers;

[Area("Admin")]
public class ContactController : Controller
{
    ContactManager cm = new ContactManager(new EFContactRepository());
    
    public IActionResult Index()
    {
        var values = cm.GetList();
        ViewBag.ActivePage = "Contacts";
        return View(values);
    }
    
    [HttpGet]
    public IActionResult AddContact()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult AddContact(Contact c)
    {
        ContactValidator av = new ContactValidator();
        ValidationResult results = av.Validate(c);
        if (results.IsValid)
        {
            c.ContactStatus = true;
            cm.AddT(c);
            return RedirectToAction("Index","Contact");
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
    public IActionResult EditContact(int id)
    {
        var values = cm.GetById(id);
        return View(values);
    }
    
    [HttpPost]
    public IActionResult EditContact(Contact c)
    {
        ContactValidator av = new ContactValidator();
        ValidationResult results = av.Validate(c);
        if (results.IsValid)
        {
            c.ContactStatus = true;
            cm.UpdateT(c);
            return RedirectToAction("Index","Contact");
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
    
    public IActionResult DeleteContact(int id)
    {
        var value = cm.GetById(id);
        cm.DeleteT(value);
        return RedirectToAction("Index","Contact");
    }
}