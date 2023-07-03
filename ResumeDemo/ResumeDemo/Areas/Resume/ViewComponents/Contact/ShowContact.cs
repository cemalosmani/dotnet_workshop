using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using DTOLayer.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ResumeDemo.Areas.Resume.ViewComponents.Contact;

public class ShowContact : ViewComponent
{
    private readonly IContactService _contactService;
    private readonly IMapper _mapper;

    public ShowContact(IMapper mapper, IContactService contactService)
    {
        _mapper = mapper;
        _contactService = contactService;
    }

    public IViewComponentResult Invoke()
    {
        var values = _mapper.Map<List<ContactDTO>>(_contactService.GetList());
        return View(values);
    }
}