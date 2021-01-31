using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sonnberg.Persistance.Entities;

namespace Sonnberg.Persistance.EntitiesConfigurations
{
    public class SonnSuiteConfiguration : IEntityTypeConfiguration<SonnSuite>
    {
        public void Configure(EntityTypeBuilder<SonnSuite> builder)
        {
            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasMaxLength(255);
        }
    }
}
