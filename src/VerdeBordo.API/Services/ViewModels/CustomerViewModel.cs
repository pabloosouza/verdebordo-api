using VerdeBordo.Domain.Entities;

namespace VerdeBordo.API.Services.ViewModels
{
    public class CustomerViewModel

    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public List<Address> Addresses { get; set; }
        public List<Embroidery> Orders { get;  set; }

        public CustomerViewModel(Guid id, string name, string contact, List<Address> addresses, List<Embroidery> orders)
        {
            Id = id;
            Name = name;
            Contact = contact;
            Addresses = addresses;
            Orders = orders;
        }

        public static CustomerViewModel Map(Customer customer)
        {
            return new CustomerViewModel
            (
                customer.Id,
                customer.Name,
                customer.Contact,
                customer.Addresses,
                customer.Orders
            );
        }
    }
}
