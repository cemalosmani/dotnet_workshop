using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class CommentManager : ICommentService
{
    ICommentDal _commentDal;

    public CommentManager(ICommentDal commentDal)
    {
        _commentDal = commentDal;
    }
    public void AddComment(Comment comment)
    {
        _commentDal.Insert(comment);
    }

    public void DeleteComment(Comment comment)
    {
        throw new NotImplementedException();
    }

    public void UpdateComment(Comment comment)
    {
        throw new NotImplementedException();
    }

    public List<Comment> GetList(int id)
    {
        return _commentDal.GetListAll(x => x.BlogId == id);
    }

    public Comment GetById(int id)
    {
        throw new NotImplementedException();
    }
}