using System;

namespace DomainHandlerBus.EventBus
{
    public class Event : EventArgs
    {
        public Guid Id { get; set; }
        public string RoutingKey { get; set; }
        public DateTime Occurred { get; private set; }

        public Event(string routingKey)
        {
            Id = Guid.NewGuid();
            RoutingKey = routingKey;
            Occurred = DateTime.Now;
        }
    }
}