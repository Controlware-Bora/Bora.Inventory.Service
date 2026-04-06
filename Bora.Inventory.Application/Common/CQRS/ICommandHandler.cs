namespace Bora.Inventory.Application.Common.CQRS;

public interface ICommandHandler
{
    Task HandleAsync(ICommand command); 
}