using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MenuService.Application.DTOs.Drinks;
using MenuService.Application.Interfaces;
using MenuService.Application.UseCases.Drinks.Queries;
using MenuService.Domain.Exceptions;

namespace MenuService.Application.UseCases.Drinks.Handlers;

public class GetDrinkForOrderHandler
{
    private readonly IDrinkRepository _drinkRepository;

    public GetDrinkForOrderHandler(IDrinkRepository drinkRepository)
    {
        _drinkRepository = drinkRepository;
    }

    public async Task<DrinkForOrderDto> HandleAsync(GetDrinkForOrderQuery query)
    {
        var drink = await _drinkRepository.GetByIdAsync(query.Id);

        if (drink is null)
            throw new NotFoundException("La bebida no fue encontrada.");

        return new DrinkForOrderDto
        {
            Id = drink.Id,
            Name = drink.Name,
            Price = drink.Price,
            Available = drink.Available
        };
    }
}
