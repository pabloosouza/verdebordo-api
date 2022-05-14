﻿using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using VerdeBordo.API.Controllers;
using VerdeBordo.API.Services.Interfaces;
using VerdeBordo.API.Services.Responses;
using VerdeBordo.API.Tests.Factory;
using VerdeBordo.Domain.Entities;
using Xunit;

namespace VerdeBordo.API.Tests
{
    public class CustomerControllerShould
    {
        #region Properties

        private readonly Mock<ICustomerService> _customerService;
        private readonly CustomerController _customerController;
        private readonly GetCustomerResponse customerReponse;
        private readonly Customer customer;

        #endregion

        #region Constructor

        public CustomerControllerShould()
        {
            _customerService = new Mock<ICustomerService>();
            _customerController = new CustomerController(_customerService.Object);

            customerReponse = CustomerFactory.GetCustomerResponse.Generate();
            customer = CustomerFactory.Customer.Generate();
        }

        #endregion

        #region GetAll

        [Fact]
        public void ReturnAllCustomers()
        {
            IActionResult result = _customerController.GetAll();

            result.Should().BeOfType<OkObjectResult>();
        }

        #endregion

        #region Add

        [Fact]
        public void AddCustomer_WhenValidInputModel()
        {
            var addCustomerInputModel = CustomerFactory.AddCustomerInputModel.Generate();

            _customerService.Setup(x => x.Add(addCustomerInputModel))
                .Returns(customerReponse);

            IActionResult result = _customerController.AddCustomer(addCustomerInputModel);

            result.Should().BeOfType<CreatedAtActionResult>();
        }
        #endregion

        #region GetById

        [Fact]
        public void ReturnCustomer_WhenValidId()
        {
            _customerService.Setup(x => x.GetById(customer.Id))
                .Returns(customerReponse);

            IActionResult result = _customerController.GetById(customer.Id);

            result.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public void ReturnNotFound_WhenCustomerNotFound()
        {
            IActionResult result = _customerController.GetById(customer.Id);

            result.Should().BeOfType<NotFoundObjectResult>();
        }

        #endregion

        #region Delete

        [Fact]
        public void LogicalDelete_WhenAsked()
        {
            _customerService.Setup(x => x.Delete(customer.Id))
                .Returns(true);

            IActionResult result = _customerController.Delete(customer.Id);

            result.Should().BeOfType<NoContentResult>();
        }

        [Fact]
        public void ReturnNotFound_WhenCustomerToDeleteNotFound()
        {
            IActionResult result = _customerController.Delete(customer.Id);

            result.Should().BeOfType<NotFoundObjectResult>();
        }

        #endregion

    }
}
