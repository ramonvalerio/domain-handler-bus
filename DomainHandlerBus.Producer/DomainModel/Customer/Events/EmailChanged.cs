using DomainHandlerBus.EventBus;

namespace DomainHandlerBus.Producer.DomainModel.Customer.Events
{
    public class EmailChanged : Event
    {
        public EmailChanged() : base("email-changed")
        {

        }
    }
}