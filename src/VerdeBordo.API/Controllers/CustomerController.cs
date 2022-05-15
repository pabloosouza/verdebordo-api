using Microsoft.AspNetCore.Mvc;
using VerdeBordo.API.InputModels;
using VerdeBordo.API.Services.Interfaces;
using VerdeBordo.API.Services.ViewModels;

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

        [HttpPost("{id}/address")]
        public IActionResult AddAddress(Guid id, AddAddressInputModel addAddressInputModel)
        {
            var response = _customerService.AddAddress(id, addAddressInputModel);

            if (response is null)
            {
                return NotFound("Cliente não encontrado.");
            }

            return CreatedAtAction(
                "GetAddressById",
                new { response.Id },
                response
                );
        }

        [HttpGet("address/{id}")]
        public IActionResult GetAddressById(Guid id)
        {
            var response = _customerService.GetAddressById(id);

            if (response is null)
            {
                return NotFound("Endereço não encontrado.");
            }

            return Ok(response);
        }

        #endregion

    }
}
