using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sonnberg.Persistance.Entities;

namespace Sonnberg.Persistance.EntitiesConfigurations
{
    public class SonnPropertyConfiguration : IEntityTypeConfiguration<SonnProperty>
    {
        public void Configure(EntityTypeBuilder<SonnProperty> builder)
        {
            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.HasMany(p => p.Suites)
                   .WithOne(s => s.Property)
                   .IsRequired();

            builder.HasMany(p => p.Photos)
                   .WithOne();
        }
    }
}
