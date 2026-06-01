using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MenuService.Domain.Exceptions;
using MenuService.Application.DTOs.Categories;
using MenuService.Application.Interfaces;
using MenuService.Application.UseCases.Categories.Commands;
using MenuService.Domain.Entities;

namespace MenuService.Application.UseCases.Categories.Handlers;

public class CreateCategoryHandler
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCategoryHandler(
        ICategoryRepository categoryRepository,
        IUnitOfWork unitOfWork)
    {
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<CategoryDto> HandleAsync(CreateCategoryCommand command)
    {
        var exists = await _categoryRepository.ExistsByNameAsync(command.Category.Name);

        if (exists)
            throw new ConflictException("Ya existe una categoría con ese nombre.");

        var category = new Category
        {
            Id = Guid.NewGuid(),
            Name = command.Category.Name,
            Description = command.Category.Description,
            CreatedAt = DateTime.UtcNow
        };

        await _categoryRepository.AddAsync(category);
        await _unitOfWork.SaveChangesAsync();

        return new CategoryDto
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description,
            CreatedAt = category.CreatedAt,
            UpdatedAt = category.UpdatedAt
        };
    }
}
