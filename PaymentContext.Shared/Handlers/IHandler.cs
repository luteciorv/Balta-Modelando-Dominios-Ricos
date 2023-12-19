using PaymentContext.Shared.Commands;

namespace PaymentContext.Shared.Handlers;

public interface IHandler<TCommand> where TCommand : ICommand
{
    ICommandResult Handle(TCommand command);
}
