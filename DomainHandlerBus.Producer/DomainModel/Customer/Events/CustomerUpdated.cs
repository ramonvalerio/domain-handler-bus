using DomainHandlerBus.EventBus;

namespace DomainHandlerBus.Producer.DomainModel.Customer.Events
{
    public class CustomerUpdated : Event
    {
        public CustomerUpdated() : base("customer-updated")
        {

        }
    }
}