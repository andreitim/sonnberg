using Sonnberg.Persistance.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Sonnberg.Persistance.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SonnbergDbContext _dbContext;

        public UnitOfWork(IRepository<SonnUser> usersRepository,
                          IRepository<SonnProperty> propertiesRepository,
                          SonnbergDbContext dbContext)
        {
            _dbContext = dbContext;
            Users = usersRepository;
            Properties = propertiesRepository;
        }

        public IRepository<SonnUser> Users { get; }

        public IRepository<SonnProperty> Properties { get; }

        public async Task<int> SaveAsync(CancellationToken cancellationToken)
            => await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
