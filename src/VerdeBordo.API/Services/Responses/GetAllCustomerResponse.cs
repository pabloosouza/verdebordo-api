using VerdeBordo.Domain.Entities;

namespace VerdeBordo.API.Services.Responses
{
    public class GetAllCustomerResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }

        public static GetAllCustomerResponse Map(Customer customer)
        {
            return new GetAllCustomerResponse
            {
                Id = customer.Id,
                Name = customer.Name,
                Contact = customer.Contact
            };
        }
    }
}
