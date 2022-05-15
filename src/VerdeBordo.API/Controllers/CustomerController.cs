using Microsoft.AspNetCore.Mvc;
using VerdeBordo.API.Models;
using VerdeBordo.API.Services.Interfaces;

namespace VerdeBordo.API.Controllers
{
    [ApiController]
    [Route("api/v1/customers")]
    public class CustomerController : ControllerBase
    {
        #region Properties

        private readonly ICustomerService _customerService;

        #endregion

        #region Constructor

        public CustomerController(ICustomerService custumerService)
        {
            _customerService = custumerService;
        }

        #endregion

        #region Methods

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_customerService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var customer = _customerService.GetById(id);

            if (customer is null)
            {
                return NotFound("Cliente não encontrado.");
            }

            return Ok(customer);
        }

        [HttpPost]
        public IActionResult AddCustomer(AddCustomerInputModel addCustomerInputModel)
        {
            var response = _customerService.Add(addCustomerInputModel);

            return CreatedAtAction(
                "GetById",
                new { response.Id },
                response
                );
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var delete = _customerService.Delete(id);

            if (!delete)
            {
                return NotFound("Cliente não encontrado.");
            }

            return NoContent();
        }

        [HttpPost("{id}/order")]
        public IActionResult Order(Guid id, AddOrderInputModel addOrderInputModel)
        { 
            var order = _customerService.Order(id, addOrderInputModel);

            if (order is null)
            {
                return NotFound("Cliente não encontrado.");
            }

            return CreatedAtAction(
                "GetOrderById",
                order.Id,
                order
                );
        }

        #endregion

    }
}
