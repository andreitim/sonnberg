using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sonnberg.Persistance.Entities;

namespace Sonnberg.Persistance.EntitiesConfigurations
{
    public class SonnPropertyConfiguration : IEntityTypeConfiguration<SonnProperty>
    {
        public void Configure(EntityTypeBuilder<SonnProperty> builder)
        {
            builder.HasOne(p => p.Location)
                   .WithMany(l => l.Properties)
                   .HasForeignKey(p => p.LocationId);

            builder.HasMany(p => p.Suites)
                   .WithOne(s => s.Property)
                   .HasForeignKey(s => s.PropertyId);

            builder.HasMany(p => p.Tags)
                   .WithMany(t => t.Properties);
        }
    }
}
