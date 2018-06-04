using DomainHandlerBus.EventBus;
using System;

namespace DomainHandlerBus.Producer.DomainModel.Customer.Commands
{
    public class CreateCustomerCommand : Command
    {
        public Customer Target { get; set; }

        public CreateCustomerCommand(Customer customer)
        {
            Target = customer;

            //try
            //{
            //    if (!customer.IsValid())
            //        SetErrorMessage("Invalid Customer.");
            //}
            //catch (Exception ex)
            //{
            //    SetErrorMessage(ex.Message);
            //}
        }
    }
}