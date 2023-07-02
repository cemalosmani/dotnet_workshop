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
public class LanguageController : Controller
{
    private readonly ILanguageService _languageService;
    private readonly IMapper _mapper;
    private readonly Context _context;
    public LanguageController(ILanguageService languageService, Context context, IMapper mapper)
    {
        _languageService = languageService;
        _context = context;
        _mapper = mapper;
    }

    public IActionResult Index()
    {
        var values = _mapper.Map<List<LanguageDTO>>(_languageService.GetList());
        ViewBag.ActivePage = "Languages";
        return View(values);
    }
    
    [HttpGet]
    public IActionResult AddLanguage()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult AddLanguage(LanguageDTO l)
    {
        var userMail = User.Identity.Name;
        var adminId = _context.Admins.Where(x => x.AdminMail == userMail).Select(y => y.AdminId).FirstOrDefault();
        LanguageValidator av = new();
        ValidationResult results = av.Validate(l);
        if (results.IsValid)
        {
            l.LanguageStatus = true;
            l.AdminId = adminId;
            _languageService.AddT(new Language()
            {
                LanguageId = l.LanguageId,
                LanguageName = l.LanguageName,
                LanguageReading = l.LanguageReading,
                LanguageSpeaking = l.LanguageSpeaking,
                LanguageWriting = l.LanguageWriting,
                LanguageStatus = l.LanguageStatus,
                AdminId = l.AdminId
            });
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
        var values = _mapper.Map<LanguageDTO>(_languageService.GetById(id));
        return View(values);
    }
    
    [HttpPost]
    public IActionResult EditLanguage(LanguageDTO l)
    {
        var userMail = User.Identity.Name;
        var adminId = _context.Admins.Where(x => x.AdminMail == userMail).Select(y => y.AdminId).FirstOrDefault();
        LanguageValidator av = new();
        ValidationResult results = av.Validate(l);
        if (results.IsValid)
        {
            l.LanguageStatus = true;
            l.AdminId = adminId;
            _languageService.UpdateT(new Language()
            {
                LanguageId = l.LanguageId,
                LanguageName = l.LanguageName,
                LanguageReading = l.LanguageReading,
                LanguageSpeaking = l.LanguageSpeaking,
                LanguageWriting = l.LanguageWriting,
                LanguageStatus = l.LanguageStatus,
                AdminId = l.AdminId
            });
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
        var value = _languageService.GetById(id);
        _languageService.DeleteT(value);
        return RedirectToAction("Index","Language");
    }
}