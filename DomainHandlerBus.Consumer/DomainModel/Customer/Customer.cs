using DomainHandlerBus.EventBus;
using System;

namespace DomainHandlerBus.Consumer.DomainModel.Customer
{
    public class Customer
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Description { get; set; }

        public double Salary { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DomainHandler _domainHandler;

        public event EventHandler<Event> CommandHandler;

        public Customer(DomainHandler domainHandler)
        {
            _domainHandler = domainHandler;
        }

        public void SaveCustomerToDataBase()
        {
            
        }
    }
}