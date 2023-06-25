using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class BlogManager : IBlogService
	{
		IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }

        public Blog GetById(int id)
        {
	        return _blogDal.GetById(id);
        }

		public List<Blog> GetBlogById(int id)
		{
			return _blogDal.GetListAll(x => x.BlogId == id);
		}

		public List<Blog> GetBlogListWithCategory()
		{
			return _blogDal.GetListWithCategory();
		}

		public List<Blog> GetListWithCategoryWithAuthor(int id)
		{
			return _blogDal.GetListWithCategoryByAuthor(id);
		}
		public List<Blog> GetBlogListByAuthor(int id)
		{
			return _blogDal.GetListAll(x => x.AuthorId == id);
		}

		public void AddT(Blog t)
		{
			_blogDal.Insert(t);
		}

		public void DeleteT(Blog t)
		{
			_blogDal.Delete(t);
		}

		public void UpdateT(Blog t)
		{
			_blogDal.Update(t);
		}

		public List<Blog> GetList()
		{
			return _blogDal.GetListAll();
		}
	}
}
