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
public class ProjectController : Controller
{
    private readonly IProjectService _projectService;
    private readonly Context _context;
    private readonly IMapper _mapper;
    
    public ProjectController(Context context, IMapper mapper, IProjectService projectService)
    {
        _context = context;
        _mapper = mapper;
        _projectService = projectService;
    }

    public IActionResult Index()
    {
        var values = _mapper.Map<List<ProjectDTO>>(_projectService.GetList());
        ViewBag.ActivePage = "Projects";
        return View(values);
    }
    
    [HttpGet]
    public IActionResult AddProject()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult AddProject(ProjectDTO p)
    {
        var userMail = User.Identity.Name;
        var adminId = _context.Admins.Where(x => x.AdminMail == userMail).Select(y => y.AdminId).FirstOrDefault();
        ProjectValidator pv = new();
        ValidationResult results = pv.Validate(p);
        if (results.IsValid)
        {
            p.ProjectStatus = true;
            p.AdminId = adminId;
            _projectService.AddT(new Project()
            {
                ProjectId = p.ProjectId,
                ProjectName = p.ProjectName,
                ProjectDetails = p.ProjectDetails,
                ProjectDate = p.ProjectDate,
                ProjectStatus = p.ProjectStatus,
                AdminId = p.AdminId
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
    public IActionResult EditProject(int id)
    {
        var values = _mapper.Map<ProjectDTO>(_projectService.GetById(id));
        return View(values);
    }
    
    [HttpPost]
    public IActionResult EditProject(ProjectDTO p)
    {
        var userMail = User.Identity.Name;
        var adminId = _context.Admins.Where(x => x.AdminMail == userMail).Select(y => y.AdminId).FirstOrDefault();
        ProjectValidator pv = new();
        ValidationResult results = pv.Validate(p);
        if (results.IsValid)
        {
            p.ProjectStatus = true;
            p.AdminId = adminId;
            _projectService.UpdateT(new Project()
            {
                ProjectId = p.ProjectId,
                ProjectName = p.ProjectName,
                ProjectDetails = p.ProjectDetails,
                ProjectDate = p.ProjectDate,
                ProjectStatus = p.ProjectStatus,
                AdminId = p.AdminId
            });
            return RedirectToAction("Index","Project");
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
    
    public IActionResult DeleteProject(int id)
    {
        var value = _projectService.GetById(id);
        _projectService.DeleteT(value);
        return RedirectToAction("Index","Project");
    }
}