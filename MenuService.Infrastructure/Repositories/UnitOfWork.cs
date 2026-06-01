using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MenuService.Application.Interfaces;
using MenuService.Infrastructure.Persistence;

namespace MenuService.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly MenuDbContext _context;

    public UnitOfWork(MenuDbContext context)
    {
        _context = context;
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}