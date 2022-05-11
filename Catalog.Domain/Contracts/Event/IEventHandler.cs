namespace Catalog.Domain.Contracts.Event
{
    public interface IEventHandler
    {

    }

    public interface IEventHandler<TEvent> : IEventHandler where TEvent : IEvent
    {
        Task Handle(TEvent @event);
    }
}
