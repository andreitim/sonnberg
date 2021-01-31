using Microsoft.EntityFrameworkCore;
using Sonnberg.Persistance;
using Sonnberg.Persistance.Entities;
using System;

namespace Sonnberg.TestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var connectionString = "Server=.\\sqlexpress;Database=Sonnberg;User ID=sa;Password=1qazXSW@;";
            var optionsBuilder = new DbContextOptionsBuilder<SonnbergDbContext>();
            optionsBuilder.EnableDetailedErrors();
            optionsBuilder.UseSqlServer(connectionString, builder => builder.EnableRetryOnFailure());
            using var dbContext = new SonnbergDbContext(optionsBuilder.Options);

            var property = new SonnProperty
            {
                Name = "gogo"
            };

            dbContext.Properties.Add(property);
            dbContext.SaveChanges();
        }
    }
}
