using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using DTOLayer.DTOs;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace ResumeDemo.Areas.Admin.Controllers;

[Area("Admin")]
public class ContactController : Controller
{
    private readonly IContactService _contactService;
    private readonly Context _context;
    private readonly IMapper _mapper;
    

    public ContactController(IContactService contactService, Context context, IMapper mapper)
    {
        _contactService = contactService;
        _context = context;
        _mapper = mapper;
    }

    public IActionResult Index()
    {
        var values = _mapper.Map<List<ContactDTO>>(_contactService.GetList());
        ViewBag.ActivePage = "Contacts";
        return View(values);
    }
    
    [HttpGet]
    public IActionResult AddContact()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult AddContact(ContactDTO c)
    {
        var userMail = User.Identity.Name;
        var adminId = _context.Admins.Where(x => x.AdminMail == userMail).Select(y => y.AdminId).FirstOrDefault();
        ContactValidator _contactValidator = new();
        ValidationResult results = _contactValidator.Validate(c);
        if (results.IsValid)
        {
            c.ContactStatus = true;
            c.AdminId = adminId;
            _contactService.AddT(new Contact()
            {
                ContactId = c.ContactId,
                ContactType = c.ContactType,
                ContactLink = c.ContactLink,
                ContactStatus = c.ContactStatus,
                AdminId = c.AdminId
            });
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
        var values = _mapper.Map<ContactDTO>(_contactService.GetById(id));
        return View(values);
    }
    
    [HttpPost]
    public IActionResult EditContact(ContactDTO c)
    {
        var userMail = User.Identity.Name;
        var adminId = _context.Admins.Where(x => x.AdminMail == userMail).Select(y => y.AdminId).FirstOrDefault();
        ContactValidator _contactValidator = new();
        ValidationResult results = _contactValidator.Validate(c);
        if (results.IsValid)
        {
            c.ContactStatus = true;
            c.AdminId = adminId;
            _contactService.UpdateT(new Contact()
            {
                ContactId = c.ContactId,
                ContactType = c.ContactType,
                ContactLink = c.ContactLink,
                ContactStatus = c.ContactStatus,
                AdminId = c.AdminId
            });
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
        var value = _contactService.GetById(id);
        _contactService.DeleteT(value);
        return RedirectToAction("Index","Contact");
    }
}