using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ResumeDemo.Areas.Resume.ViewComponents.Admin;

public class ShowAdmin : ViewComponent
{
    private readonly IAdminService _adminService;
    private readonly IMapper _mapper;

    public ShowAdmin(IMapper mapper, IAdminService adminService)
    {
        _mapper = mapper;
        _adminService = adminService;
    }

    public IViewComponentResult Invoke()
    {
        var values = _mapper.Map<AdminDTO>(_adminService.GetById(1));
        return View(values);
    }
}