using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuService.Application.UseCases.Dishes.Commands;

public class DeleteDishCommand
{
    public Guid Id { get; set; }
}
