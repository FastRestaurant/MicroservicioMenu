using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuService.Application.DTOs.Dishes;

public class DishExistsDto
{
    public Guid Id { get; set; }

    public bool Exists { get; set; }
}