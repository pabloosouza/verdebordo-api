using Microsoft.AspNetCore.Mvc;
using VerdeBordo.API.InputModels;
using VerdeBordo.API.Services.Interfaces;

namespace VerdeBordo.API.Controllers
{
    [ApiController]
    [Route("api/v1/orders")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        
        /// <summary>
        /// Lista todos os pedidos cadastrados.
        /// </summary>
        /// <returns>Lista de pedidos cadastrados.</returns>
        /// <response code="200">Lista dos pedidos cadastrados.</response>
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_orderService.GetAll());
        }

        /// <summary>
        /// Procura pedido por Id.
        /// </summary>
        /// <param name="id">Id do pedido.</param>
        /// <returns>Pedido encontrado.</returns>
        /// <response code="200">Pedido encontrado com sucesso.</response>
        /// <response code="404">Pedido não encontrado.</response>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var order = _orderService.GetById(id);

            if (order is null)
            {
                return NotFound("Pedido não encontrado.");
            }

            return Ok(order);
        }

        /// <summary>
        /// Adiciona novo pedido para cliente.
        /// </summary>
        /// <param name="id">Id do cliente</param>
        /// <param name="addOrderInputModel">Dados do pedido</param>
        /// <returns>Pedido cadastrado.</returns>
        /// <response code="201">Pedido realizado com sucesso.</response>
        /// <response code="404">Cliente não encontrado.</response>
        [HttpPost("{id}/order")]
        public IActionResult Order(Guid id, AddOrderInputModel addOrderInputModel)
        {
            var order = _orderService.Order(id, addOrderInputModel);

            if (order is null)
            {
                return NotFound("Cliente não encontrado.");
            }

            return CreatedAtAction(
                "GetById",
                new { order.Id },
                order
                );
        }

        /// <summary>
        /// Atualiza o status do pedido.
        /// </summary>
        /// <param name="id">Id do pedido.</param>
        /// <returns></returns>
        /// <response code="204">Status atualizado com sucesso.</response>
        /// <response code="400">Pedido já entregue anteriormente.</response>
        [HttpPut("{id}/update-status")]
        public IActionResult UpdateStatus(Guid id)
        {
            try
            {
                _orderService.UpdateStatus(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return NoContent();
        }

        /// <summary>
        /// Registra pagamento realizado.
        /// </summary>
        /// <param name="id">Id do pedido.</param>
        /// <param name="amountToPay">Quantidade paga.</param>
        /// <returns></returns>
        /// <response code="204">Pagamento registrado com sucesso.</response>
        /// <response code="400">Valor informado maior do que a quantidade a ser paga.</response>
        [HttpPut("{id}/pay")]
        public IActionResult Pay(Guid id, float amountToPay)
        {
            try
            {
                _orderService.Pay(id, amountToPay);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return NoContent();
        }
    }
}
