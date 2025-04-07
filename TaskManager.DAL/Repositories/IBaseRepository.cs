namespace TaskManager.DAL.Repositories
{
    public interface IBaseRepository<T>
    {
        Task<bool> Create(T model, CancellationToken cancellationToken = default);
        Task<bool> Update(T model, CancellationToken cancellationToken = default);
        Task<bool> Delete(T model, CancellationToken cancellationToken = default);
        Task<T> Get(int id, CancellationToken cancellationToken = default);
    }
}
