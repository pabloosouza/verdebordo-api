using VerdeBordo.Domain.Entities;

namespace VerdeBordo.API.Services.Responses
{
    public class GetAllCustomersViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }

        public static GetAllCustomersViewModel Map(Customer customer)
        {
            return new GetAllCustomersViewModel
            {
                Id = customer.Id,
                Name = customer.Name,
                Contact = customer.Contact
            };
        }
    }
}
