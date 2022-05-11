using Catalog.Domain.Contracts.Commands;
using Catalog.Domain.Contracts.Mediator;

namespace Catalog.Domain.Mediator
{
    public class CommandMediator : ICommandMediator
    {
        private readonly IServiceProvider _serviceProvider;

        public CommandMediator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TCommandResponse> Send<TCommand, TCommandResponse>(TCommand command) where TCommand : ICommand where TCommandResponse : ICommandResponse
        {
            ICommandHandler<TCommand, TCommandResponse>? handler = _serviceProvider.GetService(typeof(ICommandHandler<TCommand, TCommandResponse>)) as ICommandHandler<TCommand, TCommandResponse>;

            if (handler is not null)
            {
                return await handler.Handle(command);
            }

            throw new ApplicationException($"Command:  {command.GetType().Name} - doesn't have any responsible handler");
        }
    }
}
