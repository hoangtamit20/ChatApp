using ChatApp.Repository.Data;
using Microsoft.Extensions.Logging;

namespace ChatApp.Repository.Repositories
{
    public class DbRepository : IDbRepository
    {
        private readonly ChatAppDbContext _dbContext;
        private readonly ILogger<DbRepository> _logger;

        public DbRepository(ChatAppDbContext dbContex,
            ILogger<DbRepository> logger)
        {
            _dbContext = dbContex;
            _logger = logger;
        }

        public async Task<T> AddAsync<T>(T entity, bool clearTracker = false, CancellationToken cancellationToken = default)
            where T : class
        {
            var entry = await _dbContext.Set<T>().AddAsync(entity: entity, cancellationToken: cancellationToken);
            await SaveChangesAsync(clearTracker: clearTracker, cancellationToken: cancellationToken);
            return entry.Entity;
        }

        public async Task<int> AddRangeAsync<T>(IEnumerable<T> entities, bool clearTracker, CancellationToken cancellationToken)
            where T : class
        {
            await _dbContext.Set<T>().AddRangeAsync(entities: entities, cancellationToken: cancellationToken);
            var result = await SaveChangesAsync(clearTracker: clearTracker, cancellationToken: cancellationToken);
            return result;
        }





        private async Task<int> SaveChangesAsync(bool clearTracker = false, CancellationToken cancellationToken = default)
        {
            var result = await _dbContext.SaveChangesAsync(cancellationToken);
            if (clearTracker)
            {
                _dbContext.ChangeTracker.Clear();
            }
            return result;
        }



    }
}