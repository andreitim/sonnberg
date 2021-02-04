﻿using Sonnberg.Persistance.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Sonnberg.Persistance.Repositories
{
    public interface IUnitOfWork
    {
        IRepository<SonnUser> Users { get; }

        IRepository<SonnProperty> Properties { get; }

        Task<int> SaveAsync(CancellationToken cancellationToken = default);
    }
}
