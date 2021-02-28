using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Sonnberg.Persistance.Dtos;
using Sonnberg.Persistance.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sonnberg.Persistance.Repositories
{
    public class UsersRepository : Repository<SonnUser>, IUsersRepository
    {
        private readonly IMapper _mapper;

        public UsersRepository(SonnbergDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<IReadOnlyCollection<UserDto>> GetAllWithPhotosAsync(CancellationToken cancellationToken = default)
            => await _dbSet.ProjectTo<UserDto>(_mapper.ConfigurationProvider)
                           .ToListAsync(cancellationToken);
    }
}
