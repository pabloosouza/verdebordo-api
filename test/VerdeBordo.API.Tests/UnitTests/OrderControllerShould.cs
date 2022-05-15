using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using VerdeBordo.API.Controllers;
using VerdeBordo.API.InputModels;
using VerdeBordo.API.Services.Interfaces;
using VerdeBordo.API.Services.ViewModels;
using VerdeBordo.API.Tests.Factory;
using VerdeBordo.Domain.Entities;
using Xunit;

namespace VerdeBordo.API.Tests.UnitTests
{
    public class OrderControllerShould
    {
        #region Properties

        private readonly Mock<IOrderService> _orderService;
        private readonly OrderController _orderController;
        private readonly AddOrderInputModel addOrderInputModel;
        private readonly OrderViewModel orderViewModel;
        private readonly Embroidery embroidery;

        #endregion

        #region Constructor

        public OrderControllerShould()
        {
            _orderService = new Mock<IOrderService>();
            _orderController = new OrderController(_orderService.Object);

            addOrderInputModel = OrderFactory.AddOrderInputModel.Generate();
            orderViewModel = OrderFactory.OrderViewModel.Generate();
            embroidery = OrderFactory.Embroidery.Generate();
        }

        #endregion

        #region GetAll

        [Fact]
        public void ReturnAllOrders()
        {
            var result = _orderController.GetAll();

            result.Should().BeOfType<OkObjectResult>();
        }

        #endregion

        #region GetById

        [Fact]
        public void ReturnOk_WhenValidId()
        {
            _orderService.Setup(x => x.GetById(embroidery.Id))
                .Returns(orderViewModel);

            var result = _orderController.GetById(embroidery.Id);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void ReturnNotFound_WhenOrderNotFound()
        {
            var result = _orderController.GetById(embroidery.Id);

            Assert.IsType<NotFoundObjectResult>(result);
        }

        #endregion

        #region Order

        [Fact]
        public void AddOrder_WhenValidInputModel()
        {
            _orderService.Setup(x => x.Order(embroidery.Id, addOrderInputModel))
                .Returns(orderViewModel);

            var result = _orderController.Order(embroidery.Id, addOrderInputModel);

            result.Should().BeOfType<CreatedAtActionResult>();
        }

        #endregion
    }
}
