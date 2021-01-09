namespace Valenia.Common
{
    public abstract class AggregateRoot<TId> : IInternalEventHandler
        where TId : Value<TId>
    {
        public TId Id { get; protected set; }

        protected abstract void When(object @event);

        protected void Apply(object @event)
        {
            When(@event);
            EnsureValidState();
        }

        protected abstract void EnsureValidState();

        protected void ApplyToEntity(IInternalEventHandler entity, object @event)
            => entity?.Handle(@event);

        void IInternalEventHandler.Handle(object @event) => When(@event);
    }
}
