using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MenuService.Application.Interfaces;

using MenuService.Application.UseCases.Categories.Handlers;
using MenuService.Application.UseCases.Dishes.Handlers;
using MenuService.Application.UseCases.Drinks.Handlers;

using MenuService.Infrastructure.Persistence;
using MenuService.Infrastructure.Repositories;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MenuService.Infrastructure.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<MenuDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IDishRepository, DishRepository>();
        services.AddScoped<IDrinkRepository, DrinkRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<CreateCategoryHandler>();
        services.AddScoped<UpdateCategoryHandler>();
        services.AddScoped<DeleteCategoryHandler>();
        services.AddScoped<GetAllCategoriesHandler>();
        services.AddScoped<GetCategoryByIdHandler>();

        services.AddScoped<CreateDishHandler>();
        services.AddScoped<UpdateDishHandler>();
        services.AddScoped<DeleteDishHandler>();
        services.AddScoped<GetAllDishesHandler>();
        services.AddScoped<GetDishByIdHandler>();
        services.AddScoped<GetDishesByCategoryHandler>();
        services.AddScoped<GetDishForOrderHandler>();
        services.AddScoped<GetDishExistsHandler>();
        services.AddScoped<GetDishPreparationTimeHandler>();

        services.AddScoped<CreateDrinkHandler>();
        services.AddScoped<UpdateDrinkHandler>();
        services.AddScoped<DeleteDrinkHandler>();
        services.AddScoped<GetAllDrinksHandler>();
        services.AddScoped<GetDrinkByIdHandler>();
        services.AddScoped<GetDrinksByCategoryHandler>();
        services.AddScoped<GetDrinkForOrderHandler>();

        return services;
    }
}