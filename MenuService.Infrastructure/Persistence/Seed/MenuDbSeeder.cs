using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MenuService.Domain.Entities;

namespace MenuService.Infrastructure.Persistence.Seed;

public static class MenuDbSeeder
{
    public static async Task SeedAsync(MenuDbContext context)
    {
        if (context.Categories.Any())
            return;

        var bebidasId = Guid.NewGuid();
        var principalesId = Guid.NewGuid();
        var postresId = Guid.NewGuid();

        var categories = new List<Category>
        {
            new()
            {
                Id = bebidasId,
                Name = "Bebidas",
                Description = "Bebidas frías y calientes",
                CreatedAt = DateTime.UtcNow
            },
            new()
            {
                Id = principalesId,
                Name = "Platos principales",
                Description = "Comidas principales del restaurante",
                CreatedAt = DateTime.UtcNow
            },
            new()
            {
                Id = postresId,
                Name = "Postres",
                Description = "Opciones dulces para finalizar la comida",
                CreatedAt = DateTime.UtcNow
            }
        };

        var dishes = new List<Dish>
        {
            new()
            {
                Id = Guid.NewGuid(),
                CategoryId = principalesId,
                Name = "Milanesa napolitana",
                Description = "Milanesa con salsa de tomate, jamón y queso",
                Price = 7500,
                EstimatedPreparationMinutes = 20,
                Available = true,
                ImageUrl = "https://commons.wikimedia.org/wiki/Special:FilePath/Milanesa_napolitana.jpg",
                CreatedAt = DateTime.UtcNow
            },
            new()
            {
                Id = Guid.NewGuid(),
                CategoryId = postresId,
                Name = "Flan casero",
                Description = "Flan tradicional con dulce de leche",
                Price = 2800,
                EstimatedPreparationMinutes = 5,
                Available = true,
                ImageUrl = "https://images.unsplash.com/photo-1551024506-0bccd828d307",
                CreatedAt = DateTime.UtcNow
            }
        };

        var drinks = new List<Drink>
        {
            new()
            {
                Id = Guid.NewGuid(),
                CategoryId = bebidasId,
                Name = "Coca-Cola 500ml",
                Description = "Gaseosa cola individual",
                Price = 1800,
                Available = true,
                ImageUrl = "https://images.unsplash.com/photo-1622483767028-3f66f32aef97",
                CreatedAt = DateTime.UtcNow
            },
            new()
            {
                Id = Guid.NewGuid(),
                CategoryId = bebidasId,
                Name = "Agua mineral 500ml",
                Description = "Agua mineral sin gas",
                Price = 1200,
                Available = true,
                ImageUrl = "https://images.unsplash.com/photo-1523362628745-0c100150b504",
                CreatedAt = DateTime.UtcNow
            }
        };

        await context.Categories.AddRangeAsync(categories);
        await context.Dishes.AddRangeAsync(dishes);
        await context.Drinks.AddRangeAsync(drinks);

        await context.SaveChangesAsync();
    }
}
