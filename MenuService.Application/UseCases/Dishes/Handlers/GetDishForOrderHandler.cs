using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MenuService.Application.DTOs.Dishes;
using MenuService.Application.Interfaces;
using MenuService.Application.UseCases.Dishes.Queries;
using MenuService.Domain.Exceptions;

namespace MenuService.Application.UseCases.Dishes.Handlers;

public class GetDishForOrderHandler
{
    private readonly IDishRepository _dishRepository;

    public GetDishForOrderHandler(IDishRepository dishRepository)
    {
        _dishRepository = dishRepository;
    }

    public async Task<DishForOrderDto> HandleAsync(GetDishForOrderQuery query)
    {
        var dish = await _dishRepository.GetByIdAsync(query.Id);

        if (dish is null)
            throw new NotFoundException("El plato no fue encontrado.");

        return new DishForOrderDto
        {
            Id = dish.Id,
            Name = dish.Name,
            Price = dish.Price,
            Available = dish.Available,
            EstimatedPreparationMinutes = dish.EstimatedPreparationMinutes
        };
    }
}