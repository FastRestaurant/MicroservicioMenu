using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MenuService.Application.DTOs.Categories;
using MenuService.Application.Interfaces;
using MenuService.Application.UseCases.Categories.Queries;
using MenuService.Domain.Exceptions;

namespace MenuService.Application.UseCases.Categories.Handlers;

public class GetCategoryByIdHandler
{
    private readonly ICategoryRepository _categoryRepository;

    public GetCategoryByIdHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<CategoryDto> HandleAsync(GetCategoryByIdQuery query)
    {
        var category = await _categoryRepository.GetByIdAsync(query.Id);

        if (category is null)
            throw new NotFoundException("La categoría no fue encontrada.");

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
