using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace ResumeDemo.Areas.Admin.Controllers;

[Area("Admin")]
public class DashboardController : Controller
{
    private readonly IAdminService _adminService;

    public DashboardController(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public IActionResult Index()
    {
        var values = _adminService.GetById(1);
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