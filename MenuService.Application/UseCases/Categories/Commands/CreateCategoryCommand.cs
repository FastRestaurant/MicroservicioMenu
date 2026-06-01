using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MenuService.Application.DTOs.Categories;

namespace MenuService.Application.UseCases.Categories.Commands;

public class CreateCategoryCommand
{
    public CreateCategoryDto Category { get; set; } = new();
}
