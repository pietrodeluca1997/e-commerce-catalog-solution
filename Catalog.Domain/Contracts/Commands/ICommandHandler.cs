namespace Catalog.Domain.Contracts.Commands
{
    public interface ICommandHandler
    {

    }

    public interface ICommandHandler<TCommand, TCommandResponse> : ICommandHandler where TCommand : ICommand where TCommandResponse : ICommandResponse
    {
        Task<TCommandResponse> Handle(TCommand command);
    }
}
