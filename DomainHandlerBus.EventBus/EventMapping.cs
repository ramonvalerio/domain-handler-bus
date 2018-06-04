using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;

namespace DomainHandlerBus.EventBus
{
    public static class EventMapping
    {
        public static Dictionary<string, IDictionary<string, object>> Commands { get; private set; }
        public static Dictionary<string, IDictionary<string, object>> Messages { get; private set; }

        static EventMapping()
        {
            Commands = new Dictionary<string, IDictionary<string, object>>();
            Messages = new Dictionary<string, IDictionary<string, object>>();
        }

        public static void MapProducer<TEvent>(TEvent eventProducer) where TEvent : Event
        {
            if (eventProducer == null)
                throw new ArgumentNullException("Null argument");

            if (eventProducer is IDictionary<string, object>)
            {
                var message = (IDictionary<string, object>)eventProducer;
                Messages.Add($"{eventProducer.RoutingKey}", message);
            }    
            else
            {
                var properties = eventProducer.GetType().GetProperties();
                var fields = eventProducer.GetType().GetFields();
                var members = properties.Cast<MemberInfo>().Concat(fields.Cast<MemberInfo>());
                var message = members.ToDictionary(x => x.Name, x => GetValue(eventProducer, x));

                Messages.Add($"{eventProducer.RoutingKey}", message);
            }
        }

        public static void DistributeMessages()
        {
            foreach (var routingKey in Messages.Keys)
            {
                //var commands = ((Action<TEvent>)Commands[routingKey]).Invoke(Messages[routingKey~]);
            }
        }

        [SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily", Justification = "It's necessary.")]
        private static object GetValue(object obj, MemberInfo member)
        {
            if (member is PropertyInfo)
                return ((PropertyInfo)member).GetValue(obj, null);

            if (member is FieldInfo)
                return ((FieldInfo)member).GetValue(obj);

            throw new ArgumentException("Passed member is neither a PropertyInfo nor a FieldInfo.");
        }

        public static void Subscribe<TEvent>(string routingKey, Action<TEvent> command) where TEvent : Event
        {
            Commands.Add(routingKey, null);
        }
    }
}