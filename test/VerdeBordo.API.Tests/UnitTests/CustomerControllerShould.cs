using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using VerdeBordo.API.Controllers;
using VerdeBordo.API.Tests.Factory;
using VerdeBordo.Infra.Persistence;
using Xunit;

namespace VerdeBordo.API.Tests
{
    public class CustomerControllerShould
    {
        private readonly CustomerController _customerController;
        private readonly VerdeBordoContext _context;

        public CustomerControllerShould()
        {
            _context = new VerdeBordoContext();
            _customerController = new CustomerController(_context);
        }

        [Fact]
        public void ReturnAllCustomers()
        {
            IActionResult result = _customerController.GetAll();

            result.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public void AddCustomer_WhenValidInputModel()
        {
            var addCustomerInputModel = CustomerFactory.AddCustomerInputModel.Generate();

            IActionResult result = _customerController.AddCustomer(addCustomerInputModel);

            result.Should().BeOfType<CreatedAtActionResult>();
        }

        [Fact]
        public void ReturnCustomer_WhenValidId()
        {
            var customer = CustomerFactory.Customer.Generate();
            _context.Customers.Add(customer);

            IActionResult result = _customerController.GetById(customer.Id);

            result.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public void LogicalDelete_WhenAsked()
        {
            var customer = CustomerFactory.Customer.Generate();
            _context.Customers.Add(customer);

            IActionResult result = _customerController.Delete(customer.Id);

            result.Should().BeOfType<NoContentResult>();
        }
    }
}
