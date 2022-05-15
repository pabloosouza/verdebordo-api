namespace VerdeBordo.Infra.Persistence.Repositories.Interfaces
{
    public interface IBaseRepository<T>
    {
        List<T> GetAll();
        T? GetById(Guid id);
        void Add(T entity);
        void Delete(T entity);

    }
}
