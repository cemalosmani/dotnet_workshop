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
public class SkillController : Controller
{
    private readonly ISkillService _skillService;
    private readonly IMapper _mapper;
    private readonly Context _context;
    public SkillController(ISkillService skillService, Context context, IMapper mapper)
    {
        _skillService = skillService;
        _context = context;
        _mapper = mapper;
    }

    public IActionResult Index()
    {
        var values = _mapper.Map<List<SkillDTO>>(_skillService.GetList());
        ViewBag.ActivePage = "Skills";
        return View(values);
    }
    
    [HttpGet]
    public IActionResult AddSkill()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult AddSkill(SkillDTO s)
    {
        var userMail = User.Identity.Name;
        var adminId = _context.Admins.Where(x => x.AdminMail == userMail).Select(y => y.AdminId).FirstOrDefault();
        SkillValidator av = new SkillValidator();
        ValidationResult results = av.Validate(s);
        if (results.IsValid)
        {
            s.SkillStatus = true;
            s.AdminId = adminId;
            _skillService.AddT(new Skill()
            {
                SkillId = s.SkillId,
                SkillName = s.SkillName,
                SkillStatus = s.SkillStatus,
                AdminId = s.AdminId 
            });
            return RedirectToAction("Index","Skill");
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
    public IActionResult EditSkill(int id)
    {
        var values = _mapper.Map<SkillDTO>(_skillService.GetById(id));
        return View(values);
    }
    
    [HttpPost]
    public IActionResult EditSkill(SkillDTO s)
    {
        var userMail = User.Identity.Name;
        var adminId = _context.Admins.Where(x => x.AdminMail == userMail).Select(y => y.AdminId).FirstOrDefault();
        SkillValidator av = new SkillValidator();
        ValidationResult results = av.Validate(s);
        if (results.IsValid)
        {
            s.SkillStatus = true;
            s.AdminId = adminId;
            _skillService.UpdateT(new Skill()
            {
                SkillId = s.SkillId,
                SkillName = s.SkillName,
                SkillStatus = s.SkillStatus,
                AdminId = s.AdminId 
            });
            return RedirectToAction("Index","Skill");
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
    
    public IActionResult DeleteSkill(int id)
    {
        var value = _skillService.GetById(id);
        _skillService.DeleteT(value);
        return RedirectToAction("Index","Skill");
    }
}