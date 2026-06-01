using MenuService.Application.Interfaces;
using MenuService.Application.UseCases.Drinks.Commands;
using MenuService.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuService.Application.UseCases.Drinks.Handlers;

public class DeleteDrinkHandler
{
    private readonly IDrinkRepository _drinkRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteDrinkHandler(
        IDrinkRepository drinkRepository,
        IUnitOfWork unitOfWork)
    {
        _drinkRepository = drinkRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task HandleAsync(DeleteDrinkCommand command)
    {
        var drink = await _drinkRepository.GetByIdAsync(command.Id);

        if (drink is null)
            throw new NotFoundException("La bebida no fue encontrada.");

        _drinkRepository.Delete(drink);
        await _unitOfWork.SaveChangesAsync();
    }
}
