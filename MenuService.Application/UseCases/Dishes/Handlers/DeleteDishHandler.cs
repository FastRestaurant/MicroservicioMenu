using MenuService.Application.Interfaces;
using MenuService.Application.UseCases.Dishes.Commands;
using MenuService.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuService.Application.UseCases.Dishes.Handlers;

public class DeleteDishHandler
{
    private readonly IDishRepository _dishRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteDishHandler(
        IDishRepository dishRepository,
        IUnitOfWork unitOfWork)
    {
        _dishRepository = dishRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task HandleAsync(DeleteDishCommand command)
    {
        var dish = await _dishRepository.GetByIdAsync(command.Id);

        if (dish is null)
            throw new NotFoundException("El plato no fue encontrada.");

        _dishRepository.Delete(dish);
        await _unitOfWork.SaveChangesAsync();
    }
}
