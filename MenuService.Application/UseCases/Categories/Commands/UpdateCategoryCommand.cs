using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MenuService.Application.DTOs.Categories;

namespace MenuService.Application.UseCases.Categories.Commands;

public class UpdateCategoryCommand
{
    public Guid Id { get; set; }

    public UpdateCategoryDto Category { get; set; } = new();
}
