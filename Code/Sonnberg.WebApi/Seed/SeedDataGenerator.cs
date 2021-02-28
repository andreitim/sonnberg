using Sonnberg.Persistance.Entities;
using Sonnberg.Persistance.Repositories;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Sonnberg.WebApi.Seed
{
    public static class SeedDataGenerator
    {
        public static async Task GenerateAsync(IUnitOfWork unitOfWork)
        {
            if (await unitOfWork.Users.AnyAsync())
                return;

            var jsonData = await File.ReadAllTextAsync("Seed/seedData.json");
            var users = JsonSerializer.Deserialize<List<SonnUser>>(jsonData);
            users.ForEach(u => u.SetPassword("a"));

            unitOfWork.Users.AddRange(users);
            await unitOfWork.SaveAsync();
        }
    }
}
