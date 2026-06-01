using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MenuService.Application.DTOs.Dishes;

namespace MenuService.Application.UseCases.Dishes.Commands;

public class CreateDishCommand
{
    public CreateDishDto Dish { get; set; } = new();
}
