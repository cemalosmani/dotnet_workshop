using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Index = Microsoft.EntityFrameworkCore.Metadata.Internal.Index;

namespace CoreDemo.Controllers;

public class LoginController : Controller
{
    [AllowAnonymous]
    public IActionResult Index()
    {
        return View();
    }
    
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Index(Author a)
    {

        Context c = new Context();
        var dataValue = c.Authors.FirstOrDefault(x => x.AuthorMail == a.AuthorMail
                                                      && x.AuthorPassword == a.AuthorPassword);
        if (dataValue != null)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, a.AuthorMail)
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