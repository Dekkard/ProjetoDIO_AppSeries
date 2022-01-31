public interface IRepository<T>
{
    List<T> GetAll();
    T Get(int id);
    void Post(T entity);
    void Delete(int id);
    void Update(int id, T entity);
}