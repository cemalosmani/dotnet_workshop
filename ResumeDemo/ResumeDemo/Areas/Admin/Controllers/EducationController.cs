using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DTOLayer.DTOs;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace ResumeDemo.Areas.Admin.Controllers;

[Area("Admin")]
public class EducationController : Controller
{
    private readonly IEducationService _educationService;
    private readonly Context _context;
    private readonly IMapper _mapper;
    public EducationController(IEducationService educationService, Context context, IMapper mapper)
    {
        _educationService = educationService;
        _context = context;
        _mapper = mapper;
    }

    public IActionResult Index()
    {
        var values = _mapper.Map<List<EducationDTO>>(_educationService.GetList());
        ViewBag.ActivePage = "Education";
        return View(values);
    }
    
    [HttpGet]
    public IActionResult AddEducation()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult AddEducation(EducationDTO e)
    {
        var userMail = User.Identity.Name;
        var adminId = _context.Admins.Where(x => x.AdminMail == userMail).Select(y => y.AdminId).FirstOrDefault();
        EducationValidator av = new();
        ValidationResult results = av.Validate(e);
        if (results.IsValid)
        {
            e.EducationStatus = true;
            e.AdminId = adminId;
            _educationService.AddT(new Education()
            {
                EducationId = e.EducationId,
                EducationPlace = e.EducationPlace,
                EducationTitle = e.EducationTitle,
                EducationDetails = e.EducationDetails,
                EducationMark = e.EducationMark,
                EducationDate = e.EducationDate,
                EducationStatus = e.EducationStatus,
                AdminId = e.AdminId
            });
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
        var values = _mapper.Map<EducationDTO>(_educationService.GetById(id));
        return View(values);
    }
    
    [HttpPost]
    public IActionResult EditEducation(EducationDTO e)
    {
        var userMail = User.Identity.Name;
        var adminId = _context.Admins.Where(x => x.AdminMail == userMail).Select(y => y.AdminId).FirstOrDefault();
        EducationValidator av = new();
        ValidationResult results = av.Validate(e);
        if (results.IsValid)
        {
            e.EducationStatus = true;
            e.AdminId = adminId;
            _educationService.UpdateT(new Education()
            {
                EducationId = e.EducationId,
                EducationPlace = e.EducationPlace,
                EducationTitle = e.EducationTitle,
                EducationDetails = e.EducationDetails,
                EducationMark = e.EducationMark,
                EducationDate = e.EducationDate,
                EducationStatus = e.EducationStatus,
                AdminId = e.AdminId
            });
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