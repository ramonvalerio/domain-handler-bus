using DomainHandlerBus.EventBus;
using DomainHandlerBus.Producer.DomainModel.Customer.Events;
using System;

namespace DomainHandlerBus.Producer.DomainModel.Customer
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public CustomerCreated CustomerCreated { get; private set; }
        public CustomerValidated CustomerValidate { get; private set; }

        private DomainHandler _domainHandler;

        public Customer(DomainHandler domainHandler, string nome, string email, string senha)
        {
            _domainHandler = domainHandler;

            Id = Guid.NewGuid();
            Nome = nome;
            Email = email;
            Senha = senha;

            CustomerCreated = new CustomerCreated();
            _domainHandler.AddEvent(CustomerCreated);

            EventMapping.MapProducer(CustomerCreated);

            domainHandler.CommandHandler += DomainHandler_CommandHandler;
        }

        private void DomainHandler_CommandHandler(object sender, Command e)
        {
            IsValid();
        }

        public bool IsValid()
        {
            if (string.IsNullOrWhiteSpace(Nome))
                return false;

            if (string.IsNullOrWhiteSpace(Email))
                return false;

            if (string.IsNullOrWhiteSpace(Senha))
                return false;

            CustomerValidate = new CustomerValidated(this);
            _domainHandler.AddEvent(CustomerValidate);

            return true;
        }
    }
}