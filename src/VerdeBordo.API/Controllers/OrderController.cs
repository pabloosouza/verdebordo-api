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
        
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_orderService.GetAll());
        }

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

        [HttpPut("{id}/update-status")]
        public IActionResult UpdateStatus(Guid id)
        {
            try
            {
                _orderService.UpdateStatus(id);
            }
            catch 
            {
                return BadRequest("Bordado já foi entregue.");
            }

            return NoContent();
        }
    }
}
