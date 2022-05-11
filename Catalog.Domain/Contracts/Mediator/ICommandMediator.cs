using Catalog.Domain.Contracts.Commands;

namespace Catalog.Domain.Contracts.Mediator
{
    public interface ICommandMediator
    {
        Task<TCommandResponse> Send<TCommand, TCommandResponse>(TCommand command) where TCommand : ICommand where TCommandResponse : ICommandResponse;
    }
}
