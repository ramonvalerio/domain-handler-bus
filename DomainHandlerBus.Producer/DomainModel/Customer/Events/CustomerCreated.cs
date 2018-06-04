using DomainHandlerBus.EventBus;

namespace DomainHandlerBus.Producer.DomainModel.Customer.Events
{
    public class CustomerCreated : Event
    {
        public CustomerCreated() : base("customer-created")
        {

        }
    }
}