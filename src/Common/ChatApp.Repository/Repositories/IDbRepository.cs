namespace ChatApp.Repository.Repositories
{
    public interface IDbRepository
    {
        Task<int> AddRangeAsync<T>(IEnumerable<T> entities, bool clearTracker, CancellationToken cancellationToken)
            where T : class;
        Task<T> AddAsync<T>(T entity, bool clearTracker = false, CancellationToken cancellationToken = default)
            where T : class;
    }
}