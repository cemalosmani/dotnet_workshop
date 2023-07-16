using CoreDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents;

public class CommentsList : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        var commentvalues = new List<UserComment>
        {
            new UserComment
            {
                Id = 1,
                Username = "Furkan"
            },
            new UserComment
            {
                Id = 2,
                Username = "Mesut"
            },
            new UserComment
            {
                Id = 3,
                Username = "Ayşe"
            }
        };
        return View(commentvalues);
    }
}