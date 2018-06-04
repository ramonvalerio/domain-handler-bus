using DomainHandlerBus.EventBus;
using System;
using System.Collections.Generic;

namespace DomainHandlerBus.EventBus
{
    public class DomainHandler
    {
        public Dictionary<string, Queue<Event>> Topics { get; private set; }

        public Queue<Event> Events { get; private set; }
        public event EventHandler<Command> CommandHandler;

        public DomainHandler()
        {
            Topics = new Dictionary<string, Queue<Event>>();
            Events = new Queue<Event>();
        }

        public void AddEvent(Event commandEvent)
        {
            Events.Enqueue(commandEvent);
        }

        public void ExecuteCommand(Command command)
        {
            if (command == null)
                return;

            try
            {
                CommandHandler?.Invoke(this, command);
                command.Success();
            }
            catch (Exception ex)
            {
                command.SetErrorMessage(ex.Message);
                throw ex;
            }

            if (command.WasSuccess)
            {
                while (Events.Count > 0)
                {
                    var commandEvent = Events.Dequeue();

                    // Invoke the method of event
                    //commandEvent.

                    Events.TrimExcess();
                }

                EventMapping.DistributeMessages();
            }
        }
    }
}