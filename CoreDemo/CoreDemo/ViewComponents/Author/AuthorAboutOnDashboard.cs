using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Author;

public class AuthorAboutOnDashboard : ViewComponent
{
    AuthorManager atm = new AuthorManager(new EfAuthorRepository());
    Context c = new Context();
    public IViewComponentResult Invoke()
    {
        var userMail = User.Identity.Name;
        var authorId = c.Authors.Where(x => x.AuthorMail == userMail).Select(y=>y.AuthorId).FirstOrDefault();
        var values = atm.GetAuthorById(authorId);
        return View(values);
    }
}