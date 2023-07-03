using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using DTOLayer.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ResumeDemo.Areas.Resume.ViewComponents.Skill;

public class ShowSkill : ViewComponent
{
    private readonly ISkillService _skillService;
    private readonly IMapper _mapper;

    public ShowSkill(IMapper mapper, ISkillService skillService)
    {
        _mapper = mapper;
        _skillService = skillService;
    }

    public IViewComponentResult Invoke()
    {
        var values = _mapper.Map<List<SkillDTO>>(_skillService.GetList());
        return View(values);
    }
}