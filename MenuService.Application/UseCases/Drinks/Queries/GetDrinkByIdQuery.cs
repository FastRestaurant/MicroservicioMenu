using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuService.Application.UseCases.Drinks.Queries;

public class GetDrinkByIdQuery
{
    public Guid Id { get; set; }
}