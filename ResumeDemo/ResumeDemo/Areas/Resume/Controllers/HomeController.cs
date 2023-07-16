using System.Diagnostics;
using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using DTOLayer.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResumeDemo.Models;

namespace ResumeDemo.Controllers;

[Area("Resume")]
[AllowAnonymous]
public class HomeController : Controller
{
    private readonly IAdminService _adminService;
    private readonly IMapper _mapper;

    public HomeController(IAdminService adminService, IMapper mapper)
    {
        _adminService = adminService;
        _mapper = mapper;
    }

    public IActionResult Index()
    {
        return View();
    }
    public PartialViewResult HomeNavbarPartial()
    {
        var values = _mapper.Map<AdminDTO>(_adminService.GetById(1));
        return PartialView(values);
    }
}