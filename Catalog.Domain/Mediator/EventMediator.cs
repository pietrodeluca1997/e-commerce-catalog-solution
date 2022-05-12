using Catalog.Domain.Contracts.Event;
using Catalog.Domain.Contracts.Mediator;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.Domain.Mediator
{
    public class EventMediator : IEventMediator
    {
        private readonly IServiceProvider _serviceProvider;

        public EventMediator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task Publish<TEvent>(TEvent @event) where TEvent : IEvent
        {
            IEnumerable<IEventHandler<TEvent>>? handlers = _serviceProvider.GetServices(typeof(IEventHandler<TEvent>)) as IEnumerable<IEventHandler<TEvent>>;

            if (handlers is not null)
            {
                foreach (IEventHandler<TEvent> handler in handlers) await handler.Handle(@event);
            }
        }
    }
}
