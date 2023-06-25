using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
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
			var values = bm.GetListWithCategoryWithAuthor(1);
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
			if (results.IsValid)
			{
				b.BlogStatus = true;
				b.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
				b.AuthorId = 1;
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
			blog.AuthorId = 1;
			blog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
			blog.BlogStatus = true;
			bm.UpdateT(blog);
			return RedirectToAction("BlogListByAuthor");
		}
	}
}
