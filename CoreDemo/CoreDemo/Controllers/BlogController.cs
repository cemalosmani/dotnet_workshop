using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreDemo.Controllers
{
	public class BlogController : Controller
	{
		BlogManager bm = new BlogManager(new EfBlogRepository());
		CategoryManager cm = new CategoryManager(new EfCategoryRepository());
		Context c = new Context();
		public IActionResult Index()
		{
			var values = bm.GetBlogListWithCategory();
			return View(values);
		}

		public IActionResult BlogReadAll(int id)
		{
			ViewBag.i = id;
			var values = bm.GetBlogById(id);
			return View(values);
		}

		public IActionResult BlogListByAuthor()
		{
			var userMail = User.Identity.Name;
			var authorId = c.Authors.Where(x => x.AuthorMail == userMail).Select(y=>y.AuthorId).FirstOrDefault();
			var values = bm.GetListWithCategoryWithAuthor(authorId);
			return View(values);
		}
		
		[HttpGet]
		public IActionResult AddBlog()
		{
			List<SelectListItem> categoryValues = (from x in cm.GetList()
				select new SelectListItem
				{
					Text = x.CategoryName,
					Value = x.CategoryId.ToString()
				}).ToList();
			ViewBag.cv = categoryValues;
			return View();
		}
		[HttpPost]
		public IActionResult AddBlog(Blog b)
		{
			BlogValidator bv = new BlogValidator();
			ValidationResult results = bv.Validate(b);
			var userMail = User.Identity.Name;
			var authorId = c.Authors.Where(x => x.AuthorMail == userMail).Select(y=>y.AuthorId).FirstOrDefault();
			if (results.IsValid)
			{
				b.BlogStatus = true;
				b.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
				b.AuthorId = authorId;
				bm.AddT(b);
				return RedirectToAction("BlogListByAuthor","Blog");
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

		public IActionResult DeleteBlog(int id)
		{
			var blogValue = bm.GetById(id);
			bm.DeleteT(blogValue);
			return RedirectToAction("BlogListByAuthor");
		}

		[HttpGet]
		public IActionResult EditBlog(int id)
		{
			var blogValue = bm.GetById(id);
			List<SelectListItem> categoryValues = (from x in cm.GetList()
				select new SelectListItem
				{
					Text = x.CategoryName,
					Value = x.CategoryId.ToString()
				}).ToList();
			ViewBag.cv = categoryValues;
			return View(blogValue);
		}
		
		[HttpPost]
		public IActionResult EditBlog(Blog blog)
		{
			var userMail = User.Identity.Name;
			var authorId = c.Authors.Where(x => x.AuthorMail == userMail).Select(y=>y.AuthorId).FirstOrDefault();
			blog.AuthorId = authorId;
			blog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
			blog.BlogStatus = true;
			bm.UpdateT(blog);
			return RedirectToAction("BlogListByAuthor");
		}
	}
}
