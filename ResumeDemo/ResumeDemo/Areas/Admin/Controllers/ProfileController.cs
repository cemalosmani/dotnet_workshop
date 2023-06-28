using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using ResumeDemo.Areas.Admin.Models;

namespace ResumeDemo.Areas.Admin.Controllers;

[Area("Admin")]
public class ProfileController : Controller
{
    AdminManager adm = new AdminManager(new EFAdminRepository());
    Context c = new Context();
    
    [HttpGet]
    public IActionResult Index()
    {
        var values = adm.GetById(1);
        ViewBag.ActivePage = "Profile";
        return View(values);
    }
    
    [HttpPost]
    public IActionResult Index(AdminProfilePicture a)
    {
        var userMail = User.Identity.Name;
        var admin = c.Admins.FirstOrDefault(x => x.AdminMail == userMail);
        AdminValidator av = new AdminValidator();
        ValidationResult results = av.Validate(a);
        if (results.IsValid)
        {
            if (admin != null)
            {
                if (a.AdminImageFile != null)
                {
                    var extension = Path.GetExtension(a.AdminImageFile.FileName);
                    var newImageName = "profilephoto" + extension;
                    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/assets", newImageName);
                    using (var stream = new FileStream(location, FileMode.Create))
                    {
                        a.AdminImageFile.CopyTo(stream);
                    }
                    
                    if (!string.IsNullOrEmpty(admin.AdminImage) && admin.AdminImage != "defaultpp.png")
                    {
                        var oldImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/assets", admin.AdminImage);
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    admin.AdminImage = newImageName;
                }
                
                admin.AdminMail = a.AdminMail;
                admin.AdminFullName = a.AdminFullName;
                admin.AdminAbout = a.AdminAbout;
                admin.AdminPassword = a.AdminPassword;
                admin.AdminStatus = true;

                adm.UpdateT(admin);
            }

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
    public IActionResult RemoveProfilePhoto()
    {
        var admin = c.Admins.FirstOrDefault();
        if (admin != null)
        {
            if (admin.AdminImage != "defaultpp.png")
            {
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "assets", admin.AdminImage);
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
                admin.AdminImage = "defaultpp.png";
                c.SaveChanges();
            }
        }
        return RedirectToAction("Index","Profile");
    }

}