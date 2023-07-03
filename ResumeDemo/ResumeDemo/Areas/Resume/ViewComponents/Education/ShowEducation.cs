using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using DTOLayer.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ResumeDemo.Areas.Resume.ViewComponents.Education;

public class ShowEducation : ViewComponent
{
    private readonly IEducationService _educationService;
    private readonly IMapper _mapper;

    public ShowEducation(IMapper mapper, IEducationService educationService)
    {
        _mapper = mapper;
        _educationService = educationService;
    }

    public IViewComponentResult Invoke()
    {
        var values = _mapper.Map<List<EducationDTO>>(_educationService.GetList());
        return View(values);
    }
}