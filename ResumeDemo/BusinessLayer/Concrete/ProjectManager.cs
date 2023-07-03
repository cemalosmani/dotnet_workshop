using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class ProjectManager : IProjectService
{
    private readonly IProjectDal _projectDal;


    public ProjectManager(IProjectDal projectDal)
    {
        _projectDal = projectDal;
    }

    public void AddT(Project t)
    {
        _projectDal.Insert(t);
    }

    public void DeleteT(Project t)
    {
        _projectDal.Delete(t);
    }

    public void UpdateT(Project t)
    {
        _projectDal.Update(t);
    }

    public List<Project> GetList()
    {
        return _projectDal.GetListAll();
    }

    public Project GetById(int id)
    {
        return _projectDal.GetById(id);
    }
}