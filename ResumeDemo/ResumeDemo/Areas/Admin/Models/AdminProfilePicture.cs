namespace ResumeDemo.Areas.Admin.Models;

public class AdminProfilePicture : EntityLayer.Concrete.Admin
{
    public IFormFile AdminImageFile { get; set; }
}