using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers;

public class CommentController : Controller
{
    CommentManager cm = new CommentManager(new EfCommentRepository());
    [HttpGet]
    public PartialViewResult PartialAddComment()
    {
        return PartialView();
    }
    [HttpPost]
    public PartialViewResult PartialAddComment(Comment c)
    {
        c.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
        c.CommentStatus = true;
        c.BlogId = 2;
        cm.AddComment(c);
        return PartialView();
    }
    public PartialViewResult CommentListByBlog(int id)
    {
        var values = cm.GetList(id);
        return PartialView(values);
    }
}