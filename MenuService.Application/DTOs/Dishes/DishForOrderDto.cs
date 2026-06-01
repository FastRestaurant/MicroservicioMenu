using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuService.Application.DTOs.Dishes;

public class DishForOrderDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public bool Available { get; set; }

    public int EstimatedPreparationMinutes { get; set; }
}
