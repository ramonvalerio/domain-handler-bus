using DomainHandlerBus.EventBus;

namespace DomainHandlerBus.Producer.DomainModel.Customer.Commands
{
    public class ChangeEmailCommand : Command
    {
        public string OldEmail { get; private set; }
        public string NewEmail { get; private set; }

        public ChangeEmailCommand(Customer customer, string newEmail)
        {
            if (OldEmail?.ToLower() == newEmail.ToLower())
                return;

            OldEmail = customer.Email.ToLower();
            NewEmail = newEmail.ToLower();

            customer.Email = NewEmail;

            Success();
        }
    }
}