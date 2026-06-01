using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuService.Application.DTOs.Dishes;

public class DishPreparationTimeDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public int EstimatedPreparationMinutes { get; set; }
}
