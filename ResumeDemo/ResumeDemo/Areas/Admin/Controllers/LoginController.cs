using System.Security.Claims;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ResumeDemo.Areas.Admin.Controllers;

[Area("Admin")]
[AllowAnonymous]
public class LoginController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Index(EntityLayer.Concrete.Admin a)
    {

        Context c = new Context();
        var dataValue = c.Admins.FirstOrDefault(x => x.AdminMail == a.AdminMail
                                                      && x.AdminPassword == a.AdminPassword);
        if (dataValue != null)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, a.AdminMail)
            };

            var userIdentity = new ClaimsIdentity(claims, "a");
            ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
            await HttpContext.SignInAsync(principal);
            return RedirectToAction("Index", "Dashboard");
        }
        else
        {
            return View();
        }
    }

}