namespace TaskManager.DAL.Repositories
{
    public interface IBaseRepository<T>
    {
        Task<bool> Create(T entity, CancellationToken cancellationToken = default);
        Task<T> GetById(int id, CancellationToken cancellationToken = default);
        Task<List<T>> Select(CancellationToken cancellationToken = default);
        Task<bool> Delete(T entity, CancellationToken cancellationToken = default);
        Task<T> Update(T entity, CancellationToken cancellationToken = default);
    }
}
