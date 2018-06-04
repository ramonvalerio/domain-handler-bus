using DomainHandlerBus.EventBus;

namespace DomainHandlerBus.Producer.DomainModel.Customer.Events
{
    public class CustomerValidated : Event
    {
        public Customer Target { get; set; }

        public CustomerValidated(Customer target) : base("customer-validated")
        {
            Target = target;
        }
    }
}