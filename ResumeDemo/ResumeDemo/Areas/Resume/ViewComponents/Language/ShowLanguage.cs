using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using DTOLayer.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ResumeDemo.Areas.Resume.ViewComponents.Language;

public class ShowLanguage : ViewComponent
{
    private readonly ILanguageService _languageService;
    private readonly IMapper _mapper;

    public ShowLanguage(IMapper mapper, ILanguageService languageService)
    {
        _mapper = mapper;
        _languageService = languageService;
    }

    public IViewComponentResult Invoke()
    {
        var values = _mapper.Map<List<LanguageDTO>>(_languageService.GetList());
        return View(values);
    }
}