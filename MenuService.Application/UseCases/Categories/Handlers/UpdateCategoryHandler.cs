using MenuService.Application.DTOs.Categories;
using MenuService.Application.Interfaces;
using MenuService.Application.UseCases.Categories.Commands;
using MenuService.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuService.Application.UseCases.Categories.Handlers;

public class UpdateCategoryHandler
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCategoryHandler(
        ICategoryRepository categoryRepository,
        IUnitOfWork unitOfWork)
    {
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<CategoryDto> HandleAsync(UpdateCategoryCommand command)
    {
        var category = await _categoryRepository.GetByIdAsync(command.Id);

        if (category is null)
            throw new NotFoundException("La categoría no fue encontrada.");

        var categoryWithSameName = await _categoryRepository.GetByNameAsync(command.Category.Name);

        if (categoryWithSameName is not null && categoryWithSameName.Id != command.Id)
            throw new ConflictException("No se puede Actualizar Categoria: ya existe otra con ese mismo nombre, asociada a un Id diferente.");

        category.Name = command.Category.Name;
        category.Description = command.Category.Description;
        category.UpdatedAt = DateTime.UtcNow;

        _categoryRepository.Update(category);
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
