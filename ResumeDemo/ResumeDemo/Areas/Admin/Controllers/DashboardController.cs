using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using DTOLayer.DTOs;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace ResumeDemo.Areas.Admin.Controllers;

[Area("Admin")]
public class DashboardController : Controller
{
    private readonly IAdminService _adminService;
    private readonly IMapper _mapper;
    private readonly Context _context;

    public DashboardController(IAdminService adminService, IMapper mapper, Context context)
    {
        _adminService = adminService;
        _mapper = mapper;
        _context = context;
    }

    public IActionResult Index()
    {
        var adminMail = User.Identity.Name;
        var adminId = _context.Admins.Where(x => x.AdminMail == adminMail).Select(y => y.AdminId).FirstOrDefault();
        var values = _mapper.Map<AdminDTO>(_adminService.GetById(adminId));
        ViewBag.ActivePage = "";
        return View(values);
    }

    public PartialViewResult AdminNavbarPartial()
    {
        return PartialView();
    }

    public PartialViewResult AdminTopBarPartial()
    {
        return PartialView();
    }
    
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();
        return RedirectToAction("Index", "Login");
    }
}