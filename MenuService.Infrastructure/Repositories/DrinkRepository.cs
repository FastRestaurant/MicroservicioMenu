using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MenuService.Application.Interfaces;
using MenuService.Domain.Entities;
using MenuService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace MenuService.Infrastructure.Repositories;

public class DrinkRepository : IDrinkRepository
{
    private readonly MenuDbContext _context;

    public DrinkRepository(MenuDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Drink>> GetAllAsync()
    {
        return await _context.Drinks
            .AsNoTracking()
            .Include(x => x.Category)
            .ToListAsync();
    }

    public async Task<Drink?> GetByIdAsync(Guid id)
    {
        return await _context.Drinks
            .Include(x => x.Category)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<Drink>> GetByCategoryIdAsync(Guid categoryId)
    {
        return await _context.Drinks
            .AsNoTracking()
            .Include(x => x.Category)
            .Where(x => x.CategoryId == categoryId)
            .ToListAsync();
    }

    public async Task AddAsync(Drink drink)
    {
        await _context.Drinks.AddAsync(drink);
    }

    public void Update(Drink drink)
    {
        _context.Drinks.Update(drink);
    }

    public void Delete(Drink drink)
    {
        _context.Drinks.Remove(drink);
    }
}
