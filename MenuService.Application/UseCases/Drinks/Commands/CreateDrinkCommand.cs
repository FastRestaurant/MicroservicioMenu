using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MenuService.Application.DTOs.Drinks;

namespace MenuService.Application.UseCases.Drinks.Commands;

public class CreateDrinkCommand
{
    public CreateDrinkDto Drink { get; set; } = new();
}
