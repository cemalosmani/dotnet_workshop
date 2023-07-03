using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DTOLayer.DTOs;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace ResumeDemo.Areas.Admin.Controllers;

[Area("Admin")]
public class ProfileController : Controller
{
    private readonly IAdminService _adminService;
    private readonly IMapper _mapper;
    private readonly Context _context;

    public ProfileController(IAdminService adminService, Context context, IMapper mapper)
    {
        _adminService = adminService;
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var userMail = User.Identity.Name;
        var adminId = _context.Admins.Where(x => x.AdminMail == userMail).Select(y=>y.AdminId).FirstOrDefault();
        var values = _mapper.Map<AdminDTO>(_adminService.GetById(adminId));
        ViewBag.ActivePage = "Profile";
        return View(values);
    }
    
    [HttpPost]
    public IActionResult Index(AdminProfilePictureDTO a)
    {
        var userMail = User.Identity.Name;
        var admin = _context.Admins.FirstOrDefault(x => x.AdminMail == userMail);
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

                a.AdminId = admin.AdminId;
                a.AdminStatus = true;

                _adminService.UpdateT(new EntityLayer.Concrete.Admin()
                {
                    AdminId = a.AdminId,
                    AdminImage = admin.AdminImage,
                    AdminMail = a.AdminMail,
                    AdminFullName = a.AdminFullName,
                    AdminAbout = a.AdminAbout,
                    AdminPassword = a.AdminPassword,
                    AdminStatus = a.AdminStatus
                });
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
        var admin = _context.Admins.FirstOrDefault();
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
                _context.SaveChanges();
            }
        }
        return RedirectToAction("Index","Profile");
    }

}