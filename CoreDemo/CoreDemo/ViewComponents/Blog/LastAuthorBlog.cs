using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Blog;

public class LastAuthorBlog : ViewComponent
{
    BlogManager bm = new BlogManager(new EfBlogRepository());

    public IViewComponentResult Invoke()
    {
        var values = bm.GetBlogListByAuthor(1);
        return View(values);
    }
}