using Sonnberg.Persistance.Dtos;
using Sonnberg.Persistance.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sonnberg.Persistance.Repositories
{
    public interface IUsersRepository : IRepository<SonnUser>
    {
        Task<IReadOnlyCollection<UserDto>> GetAllWithPhotosAsync(CancellationToken cancellationToken = default);
    }
}