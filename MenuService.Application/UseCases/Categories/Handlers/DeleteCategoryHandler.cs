using MenuService.Application.Interfaces;
using MenuService.Application.UseCases.Categories.Commands;
using MenuService.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuService.Application.UseCases.Categories.Handlers;

public class DeleteCategoryHandler
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCategoryHandler(
        ICategoryRepository categoryRepository,
        IUnitOfWork unitOfWork)
    {
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task HandleAsync(DeleteCategoryCommand command)
    {
        var category = await _categoryRepository.GetByIdAsync(command.Id);

        if (category is null)
            throw new NotFoundException("La categoría no fue encontrada.");

        _categoryRepository.Delete(category);
        await _unitOfWork.SaveChangesAsync();
    }
}
