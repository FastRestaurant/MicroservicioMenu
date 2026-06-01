using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MenuService.Application.DTOs.Dishes;
using MenuService.Application.Interfaces;
using MenuService.Application.UseCases.Dishes.Queries;

namespace MenuService.Application.UseCases.Dishes.Handlers;

public class GetDishExistsHandler
{
    private readonly IDishRepository _dishRepository;

    public GetDishExistsHandler(IDishRepository dishRepository)
    {
        _dishRepository = dishRepository;
    }

    public async Task<DishExistsDto> HandleAsync(GetDishExistsQuery query)
    {
        var dish = await _dishRepository.GetByIdAsync(query.Id);

        return new DishExistsDto
        {
            Id = query.Id,
            Exists = dish is not null
        };
    }
}
