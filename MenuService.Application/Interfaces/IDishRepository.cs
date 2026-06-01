using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MenuService.Domain.Entities;

namespace MenuService.Application.Interfaces;

public interface IDishRepository
{
    Task<IEnumerable<Dish>> GetAllAsync();
    Task<Dish?> GetByIdAsync(Guid id);
    Task<IEnumerable<Dish>> GetByCategoryIdAsync(Guid categoryId);
    Task AddAsync(Dish dish);
    void Update(Dish dish);
    void Delete(Dish dish);
}
