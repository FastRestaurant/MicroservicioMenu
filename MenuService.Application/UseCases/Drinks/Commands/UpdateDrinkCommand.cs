using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MenuService.Application.DTOs.Drinks;

namespace MenuService.Application.UseCases.Drinks.Commands;

public class UpdateDrinkCommand
{
    public Guid Id { get; set; }

    public UpdateDrinkDto Drink { get; set; } = new();
}
