using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using DTOLayer.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ResumeDemo.Areas.Resume.ViewComponents.Experience;

public class ShowExperience : ViewComponent
{
    private readonly IExperienceService _experienceService;
    private readonly IMapper _mapper;

    public ShowExperience(IMapper mapper, IExperienceService experienceService)
    {
        _mapper = mapper;
        _experienceService = experienceService;
    }

    public IViewComponentResult Invoke()
    {
        var values = _mapper.Map<List<ExperienceDTO>>(_experienceService.GetList());
        return View(values);
    }
}