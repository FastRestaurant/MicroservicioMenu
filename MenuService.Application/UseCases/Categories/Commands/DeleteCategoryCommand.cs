using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuService.Application.UseCases.Categories.Commands;

public class DeleteCategoryCommand
{
    public Guid Id { get; set; }
}
