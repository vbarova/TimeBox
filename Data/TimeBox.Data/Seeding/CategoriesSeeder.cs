namespace TimeBox.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using TimeBox.Data.Models;

    public class CategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Categories.Any())
            {
                return;
            }

            await dbContext.Categories.AddAsync(new Category { Name = "Лични задачи" });
            await dbContext.Categories.AddAsync(new Category { Name = "Семейни задачи" });
            await dbContext.Categories.AddAsync(new Category { Name = "Служебни задачи" });
            await dbContext.Categories.AddAsync(new Category { Name = "Образование" });
            await dbContext.Categories.AddAsync(new Category { Name = "Спорт" });

            await dbContext.SaveChangesAsync();
        }
    }
}
