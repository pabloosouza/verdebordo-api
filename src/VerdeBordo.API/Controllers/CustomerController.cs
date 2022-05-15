using Microsoft.AspNetCore.Mvc;
using VerdeBordo.API.InputModels;
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

        /// <summary>
        /// Lista todos os clientes cadastrados.
        /// </summary>
        /// <returns>Lista dos clientes cadastrados.</returns>
        /// <response code="200">Lista de clientes cadastrados.</response>
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_customerService.GetAll());
        }

        /// <summary>
        /// Procura cliente por Id.
        /// </summary>
        /// <param name="id">Id do cliente.</param>
        /// <returns>Cliente encontrado.</returns>
        /// <response code="200">Cliente encontrado com sucesso.</response>
        /// <response code="404">Cleinte não encontrado.</response>
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

        /// <summary>
        /// Cadastra novo cliente.
        /// </summary>
        /// <param name="addCustomerInputModel">Dados do cliente.</param>
        /// <returns>Cliente cadastrado.</returns>
        /// <response code="201">Cliente cadastrado com sucesso.</response>
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

        /// <summary>
        /// Exclui cliente do banco de dados.
        /// </summary>
        /// <param name="id">Id do cliente.</param>
        /// <returns></returns>
        /// <response code="204">Cliente excluido com sucesso.</response>
        /// <response code="404">Cliente não encontrado.</response>
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

        /// <summary>
        /// Adiciona novo endereço para cliente.
        /// </summary>
        /// <param name="id">Id do cliente.</param>
        /// <param name="addAddressInputModel">Dados do endereço.</param>
        /// <returns>Endereço cadastrado.</returns>
        /// <response code="201">Endereço cadastrado com sucesso.</response>
        /// <response code="404">Cliente não encontrado.</response>
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

        /// <summary>
        /// Lista endereço do cliente por Id.
        /// </summary>
        /// <param name="id">Id do endereço.</param>
        /// <returns>Endereço do cliente.</returns>
        /// <response code="200">Endereço encontrado com sucesso.</response>
        /// <response code="404">Endereço não encontrado.</response>
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
