using Microsoft.AspNetCore.Mvc;
using VerdeBordo.Domain.Entities;
using VerdeBordo.Infra.Persistence;

namespace VerdeBordo.API.Controllers
{
    [ApiController]
    [Route("api/v1/customers")]
    public class CustomerController : ControllerBase
    {
        private readonly VerdeBordoContext _context;

        public CustomerController(VerdeBordoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Customers);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var customer = _context
                .Customers.SingleOrDefault(x => x.Id == id);

            if (customer is null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpPost]
        public IActionResult AddCustomer(AddCustomerInputModel addCustomerInputModel)
        {
            var customer = new Customer(addCustomerInputModel.Name, addCustomerInputModel.Contact, addCustomerInputModel.Address);

            _context.Customers.Add(customer);

            return CreatedAtAction(
                "GetById",
                new { customer.Id },
                customer
                );
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var customer = _context
                .Customers.SingleOrDefault(x => x.Id == id);

            if (customer is null)
            {
                return NotFound();
            }

            customer.Delete();

            return NoContent();
        }
    }
}
