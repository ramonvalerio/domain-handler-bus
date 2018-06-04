using DomainHandlerBus.EventBus;
using DomainHandlerBus.Producer.DomainModel.Customer;
using DomainHandlerBus.Producer.DomainModel.Customer.Commands;
using Xunit;

namespace EventSourcingSample.Test
{
    public class CustomerTest
    {
        private DomainHandler _domainHandler = new DomainHandler();

        [Fact]
        public void CustomerCreated()
        {
            var customer = new Customer(_domainHandler, "Ramon Valerio", "ramonvalerios@gmail.com", "123456");

            var createCustomerCommand = new CreateCustomerCommand(customer);

            _domainHandler.ExecuteCommand(createCustomerCommand);

            Assert.True(createCustomerCommand.WasSuccess);
        }

        //[Fact]
        //public void CustomerIsValid()
        //{
        //    var customer = new Customer(_domainHandler, "Ramon Valerio", "ramonvalerios@gmail.com", "123456");

        //    var actual = customer.IsValid();
        //    var expected = true;

        //    Assert.Equal(expected, actual);
        //}

        //[Fact]
        //public void CustomerEmailChanged()
        //{
        //    var customer = new Customer(_domainHandler, "Ramon Valerio", "ramonvalerios@gmail.com", "123456");

        //    var actual = customer.Email;
        //    var expected = "rvalerio@gmail.com";

        //    _domainHandler.ExecuteCommand(new ChangeEmailCommand(customer, expected));

        //    Assert.Equal(expected, customer.Email);
        //}

        //[Fact]
        //public void CustomerOldEmailIsNotEqualThanNewEmail()
        //{
        //    var customer = new Customer(_domainHandler, "Ramon Valerio", "ramonvalerios@gmail.com", "123456");

        //    var actual = customer.Email;
        //    var expected = "rvalerio@gmail.com";

        //    var changedEmailCommand = new ChangeEmailCommand(customer, expected);

        //    _domainHandler.ExecuteCommand(changedEmailCommand);

        //    Assert.True(changedEmailCommand.WasSuccess);
        //}
    }
}