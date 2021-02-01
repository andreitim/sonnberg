﻿using Microsoft.EntityFrameworkCore;
using Sonnberg.Persistance.Entities;
using Sonnberg.Persistance.EntitiesConfigurations;

namespace Sonnberg.Persistance
{
    public class SonnbergDbContext : DbContext
    {
        public SonnbergDbContext() : base()
        {
        }

        public SonnbergDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<SonnUser> Users { get; set; }

        public DbSet<SonnProperty> Properties { get; set; }

        public DbSet<SonnSuite> Suites { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SonnSuiteConfiguration());
            modelBuilder.ApplyConfiguration(new SonnPropertyConfiguration());
        }
    }
}
