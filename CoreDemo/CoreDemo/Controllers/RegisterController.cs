using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers;

public class RegisterController : Controller
{
    AuthorManager atm = new AuthorManager(new EfAuthorRepository());
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(Author a)
    {
        AuthorValidator av = new AuthorValidator();
        ValidationResult results = av.Validate(a);
        if (results.IsValid)
        {
            a.AuthorStatus = true;
            a.AuthorAbout = "Deneme";
            atm.AddT(a);
            return RedirectToAction("Index","Blog");
        }
        else
        {
            foreach (var item in results.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
        }

        return View();
    }
}