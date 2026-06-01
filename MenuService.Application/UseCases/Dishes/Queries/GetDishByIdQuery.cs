using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuService.Application.UseCases.Dishes.Queries;

public class GetDishByIdQuery
{
    public Guid Id { get; set; }
}
