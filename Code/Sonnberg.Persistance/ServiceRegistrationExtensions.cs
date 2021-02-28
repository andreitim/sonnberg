using Microsoft.Extensions.DependencyInjection;
using Sonnberg.Persistance.Entities;
using Sonnberg.Persistance.Repositories;

namespace Sonnberg.Persistance
{
    public static class ServiceRegistrationExtensions
    {
        public static IServiceCollection AddPersistanceServices(this IServiceCollection services)
        {
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IRepository<SonnProperty>, Repository<SonnProperty>>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
