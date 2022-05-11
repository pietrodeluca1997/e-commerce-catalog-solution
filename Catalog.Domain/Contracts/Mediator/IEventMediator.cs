using Catalog.Domain.Contracts.Event;

namespace Catalog.Domain.Contracts.Mediator
{
    public interface IEventMediator
    {
        Task Publish<TEvent>(TEvent @event) where TEvent : IEvent;
    }
}
