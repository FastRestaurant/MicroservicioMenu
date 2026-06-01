using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MenuService.Application.DTOs.Dishes;

namespace MenuService.Application.UseCases.Dishes.Commands;

public class UpdateDishCommand
{
    public Guid Id { get; set; }

    public UpdateDishDto Dish { get; set; } = new();
}
