using MenuService.Application.DTOs.Dishes;
using MenuService.Application.Interfaces;
using MenuService.Application.UseCases.Dishes.Commands;
using MenuService.Domain.Entities;
using MenuService.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuService.Application.UseCases.Dishes.Handlers;

public class CreateDishHandler
{
    private readonly IDishRepository _dishRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateDishHandler(
        IDishRepository dishRepository,
        ICategoryRepository categoryRepository,
        IUnitOfWork unitOfWork)
    {
        _dishRepository = dishRepository;
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<DishDto> HandleAsync(CreateDishCommand command)
    {
        var category = await _categoryRepository.GetByIdAsync(command.Dish.CategoryId);

        if (category is null)
            throw new NotFoundException("La categoría no fue encontrada.");

        if (command.Dish.Price <= 0)
            throw new BusinessRuleException("El precio del plato debe ser mayor a cero.");

        if (command.Dish.EstimatedPreparationMinutes <= 0)
            throw new BusinessRuleException("El tiempo estimado de preparación debe ser mayor a cero.");

        var dish = new Dish
        {
            Id = Guid.NewGuid(),
            CategoryId = command.Dish.CategoryId,
            Name = command.Dish.Name,
            Description = command.Dish.Description,
            Price = command.Dish.Price,
            EstimatedPreparationMinutes = command.Dish.EstimatedPreparationMinutes,
            Available = command.Dish.Available,
            ImageUrl = command.Dish.ImageUrl,
            CreatedAt = DateTime.UtcNow
        };

        await _dishRepository.AddAsync(dish);
        await _unitOfWork.SaveChangesAsync();

        return new DishDto
        {
            Id = dish.Id,
            CategoryId = dish.CategoryId,
            CategoryName = category.Name,
            Name = dish.Name,
            Description = dish.Description,
            Price = dish.Price,
            EstimatedPreparationMinutes = dish.EstimatedPreparationMinutes,
            Available = dish.Available,
            ImageUrl = dish.ImageUrl,
            CreatedAt = dish.CreatedAt,
            UpdatedAt = dish.UpdatedAt
        };
    }
}