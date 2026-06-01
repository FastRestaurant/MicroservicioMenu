using MenuService.Application.DTOs.Dishes;
using MenuService.Application.Interfaces;
using MenuService.Application.UseCases.Dishes.Commands;
using MenuService.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuService.Application.UseCases.Dishes.Handlers;

public class UpdateDishHandler
{
    private readonly IDishRepository _dishRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateDishHandler(
        IDishRepository dishRepository,
        ICategoryRepository categoryRepository,
        IUnitOfWork unitOfWork)
    {
        _dishRepository = dishRepository;
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<DishDto> HandleAsync(UpdateDishCommand command)
    {
        var dish = await _dishRepository.GetByIdAsync(command.Id);

        if (dish is null)
            throw new NotFoundException("El plato no fue encontrada.");

        var category = await _categoryRepository.GetByIdAsync(command.Dish.CategoryId);

        if (category is null)
            throw new NotFoundException("La categoría no fue encontrada.");

        if (command.Dish.Price <= 0)
            throw new BusinessRuleException("El precio del plato debe ser mayor a cero.");

        if (command.Dish.EstimatedPreparationMinutes <= 0)
            throw new BusinessRuleException("El tiempo estimado de preparación debe ser mayor a cero.");

        dish.CategoryId = command.Dish.CategoryId;
        dish.Name = command.Dish.Name;
        dish.Description = command.Dish.Description;
        dish.Price = command.Dish.Price;
        dish.EstimatedPreparationMinutes = command.Dish.EstimatedPreparationMinutes;
        dish.Available = command.Dish.Available;
        dish.ImageUrl = command.Dish.ImageUrl;
        dish.UpdatedAt = DateTime.UtcNow;

        _dishRepository.Update(dish);
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
