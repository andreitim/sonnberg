using Sonnberg.Persistance.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Sonnberg.Persistance.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SonnbergDbContext _dbContext;

        public UnitOfWork(IUsersRepository usersRepository,
                          IRepository<SonnProperty> propertiesRepository,
                          SonnbergDbContext dbContext)
        {
            _dbContext = dbContext;
            Users = usersRepository;
            Properties = propertiesRepository;
        }

        public IUsersRepository Users { get; }

        public IRepository<SonnProperty> Properties { get; }

        public async Task<int> SaveAsync(CancellationToken cancellationToken = default)
            => await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
