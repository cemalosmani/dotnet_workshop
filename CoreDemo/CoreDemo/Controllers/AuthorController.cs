using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using CoreDemo.Models;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers;

[Authorize]
public class AuthorController : Controller
{
    AuthorManager atm = new AuthorManager(new EfAuthorRepository());
    public IActionResult Index()
    {
        var userMail = User.Identity.Name;
        ViewBag.v = userMail;
        Context c = new Context();
        var authorName = c.Authors.Where(x => x.AuthorMail == userMail).Select(y=>y.AuthorName).FirstOrDefault();
        ViewBag.v1 = authorName;
        return View();
    }

    public IActionResult AuthorProfile()
    {
        return View();
    }
    
    public IActionResult AuthorMail()
    {
        return View();
    }
    
    public IActionResult Test()
    {
        return View();
    }
    
    public PartialViewResult AuthorNavbarPartial()
    {
        return PartialView();
    }
    
    public PartialViewResult AuthorFooterPartial()
    {
        return PartialView();
    }
    [HttpGet]
    public IActionResult AuthorEditProfile()
    {
        Context c = new Context();
        var userMail = User.Identity.Name;
        var authorId = c.Authors.Where(x => x.AuthorMail == userMail).Select(y=>y.AuthorId).FirstOrDefault();
        var authorValues = atm.GetById(authorId);
        return View(authorValues);
    }
    [HttpPost]
    public IActionResult AuthorEditProfile(Author a)
    {
        AuthorValidator av = new AuthorValidator();
        ValidationResult results = av.Validate(a);
        if (results.IsValid)
        {
            atm.UpdateT(a);
            return RedirectToAction("Index", "Dashboard");
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

    [HttpGet]
    public IActionResult AddAuthor()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult AddAuthor(AddProfileImage a)
    {
        Author author = new Author();
        if (a.AuthorImage != null)
        {
            var extension = Path.GetExtension(a.AuthorImage.FileName);
            var newImageName = Guid.NewGuid() + extension;
            var location = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/AuthorImageFiles/", newImageName);
            var stream = new FileStream(location, FileMode.Create);
            a.AuthorImage.CopyTo(stream);
            author.AuthorImage = newImageName;
        }

        author.AuthorMail = a.AuthorMail;
        author.AuthorName = a.AuthorName;
        author.AuthorPassword = a.AuthorPassword;
        author.AuthorAbout = a.AuthorAbout;
        author.AuthorStatus = true;
        atm.AddT(author);
        return RedirectToAction("Index","Dashboard");
    }
}