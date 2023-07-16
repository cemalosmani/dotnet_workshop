namespace BusinessLayer.Abstract;

public interface IGenericService<T>
{
    void AddT(T t);
    void DeleteT(T t);
    void UpdateT(T t);
    List<T> GetList();
    T GetById(int id);
}