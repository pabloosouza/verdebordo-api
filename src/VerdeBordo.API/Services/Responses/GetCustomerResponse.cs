using VerdeBordo.Domain.Entities;

namespace VerdeBordo.API.Services.Responses
{
    public class GetCustomerResponse

    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public List<Address> Addresses { get; set; }
        public List<Embroidery> Orders { get;  set; }

        public static GetCustomerResponse Map(Customer customer)
        {
            return new GetCustomerResponse
            {
                Id = customer.Id,
                Name = customer.Name,
                Contact = customer.Contact,
                Addresses = customer.Addresses,
                Orders = customer.Orders
            };
        }
    }
}
