using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers;

public class MessageController : Controller
{
    MessageManager mm = new MessageManager(new EfMessageRepository());
    public IActionResult Inbox()
    {
        int id = 1;
        var values = mm.GetInboxListByAuthor(id);
        return View(values);
    }
    public IActionResult MessageDetails(int id)
    {
        var value = mm.GetById(id);
        return View(value);
    }
}