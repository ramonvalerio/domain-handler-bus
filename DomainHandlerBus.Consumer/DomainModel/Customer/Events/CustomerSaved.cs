using DomainHandlerBus.EventBus;

namespace DomainHandlerBus.Consumer.DomainModel.Customer.Events
{
    public class CustomerSaved : Event
    {
        public CustomerSaved() : base("customer-saved")
        {

        }
    }
}