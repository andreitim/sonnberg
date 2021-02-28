using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sonnberg.Persistance.Entities;

namespace Sonnberg.Persistance.EntitiesConfigurations
{
    public class SonnUserConfiguration : IEntityTypeConfiguration<SonnUser>
    {
        public void Configure(EntityTypeBuilder<SonnUser> builder)
        {
            builder.HasMany(u => u.Locations)
                   .WithOne(l => l.User)
                   .IsRequired();

            builder.HasMany(u => u.Properties)
                   .WithOne(p => p.User)
                   .IsRequired();

            builder.HasMany(u => u.Photos)
                   .WithOne(p => p.User)
                   .IsRequired();
        }
    }
}
