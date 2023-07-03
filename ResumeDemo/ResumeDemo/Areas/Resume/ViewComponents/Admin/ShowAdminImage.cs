using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using DTOLayer.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ResumeDemo.Areas.Resume.ViewComponents.Admin;

public class ShowAdminImage : ViewComponent
{
    private readonly IAdminService _adminService;
    private readonly IMapper _mapper;

    public ShowAdminImage(IAdminService adminService, IMapper mapper)
    {
        _adminService = adminService;
        _mapper = mapper;
    }

    public IViewComponentResult Invoke()
    {
        var values = _mapper.Map<AdminDTO>(_adminService.GetById(1));
        return View(values);
    }
}