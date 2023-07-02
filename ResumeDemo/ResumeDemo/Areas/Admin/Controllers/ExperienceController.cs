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
public class ExperienceController : Controller
{
    private readonly IExperienceService _experienceService;
    private readonly IMapper _mapper;
    private readonly Context _context;
    public ExperienceController(IExperienceService experienceService, Context context, IMapper mapper)
    {
        _experienceService = experienceService;
        _context = context;
        _mapper = mapper;
    }

    public IActionResult Index()
    {
        var values = _mapper.Map<List<ExperienceDTO>>(_experienceService.GetList());
        ViewBag.ActivePage = "Experience";
        return View(values);
    }
    
    [HttpGet]
    public IActionResult AddExperience()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult AddExperience(ExperienceDTO e)
    {
        var userMail = User.Identity.Name;
        var adminId = _context.Admins.Where(x => x.AdminMail == userMail).Select(y => y.AdminId).FirstOrDefault();
        ExperienceValidator av = new();
        ValidationResult results = av.Validate(e);
        if (results.IsValid)
        {
            e.ExperienceStatus = true;
            e.AdminId = adminId;
            _experienceService.AddT(new Experience()
            {
                ExperienceId = e.ExperienceId,
                ExperienceTitle = e.ExperienceTitle,
                ExperiencePlace = e.ExperiencePlace,
                ExperienceDetails = e.ExperienceDetails,
                ExperienceDate = e.ExperienceDate,
                ExperienceStatus = e.ExperienceStatus,
                AdminId = e.AdminId
            });
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
        var values = _mapper.Map<ExperienceDTO>(_experienceService.GetById(id));
        return View(values);
    }
    
    [HttpPost]
    public IActionResult EditExperience(ExperienceDTO e)
    {
        var userMail = User.Identity.Name;
        var adminId = _context.Admins.Where(x => x.AdminMail == userMail).Select(y => y.AdminId).FirstOrDefault();
        ExperienceValidator av = new();
        ValidationResult results = av.Validate(e);
        if (results.IsValid)
        {
            e.ExperienceStatus = true;
            e.AdminId = adminId;
            _experienceService.UpdateT(new Experience()
            {
                ExperienceId = e.ExperienceId,
                ExperienceTitle = e.ExperienceTitle,
                ExperiencePlace = e.ExperiencePlace,
                ExperienceDetails = e.ExperienceDetails,
                ExperienceDate = e.ExperienceDate,
                ExperienceStatus = e.ExperienceStatus,
                AdminId = e.AdminId
            });
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