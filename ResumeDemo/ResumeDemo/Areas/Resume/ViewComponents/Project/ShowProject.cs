using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DTOLayer.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ResumeDemo.Areas.Resume.ViewComponents.Project;

public class ShowProject : ViewComponent
{
    private readonly IProjectService _projectService;
    private readonly IMapper _mapper;

    public ShowProject(IMapper mapper, IProjectService projectService)
    {
        _mapper = mapper;
        _projectService = projectService;
    }

    public IViewComponentResult Invoke()
    {
        var values = _mapper.Map<List<ProjectDTO>>(_projectService.GetList());
        return View(values);
    }
}