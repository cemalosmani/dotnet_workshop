using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class LanguageManager : ILanguageService
{
    private readonly ILanguageDal _languageDal;

    public LanguageManager(ILanguageDal languageDal)
    {
        _languageDal = languageDal;
    }

    public void AddT(Language t)
    {
        _languageDal.Insert(t);
    }

    public void DeleteT(Language t)
    {
        _languageDal.Delete(t);
    }

    public void UpdateT(Language t)
    {
        _languageDal.Update(t);
    }

    public List<Language> GetList()
    {
        return _languageDal.GetListAll();
    }

    public Language GetById(int id)
    {
        return _languageDal.GetById(id);
    }
}