using VerdeBordo.Domain.Entities;

namespace VerdeBordo.API.Services.ViewModels
{
    public class GetAllCustomersViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }

        public GetAllCustomersViewModel(Guid id, string name, string contact)
        {
            Id = id;
            Name = name;
            Contact = contact;
        }

        public static GetAllCustomersViewModel Map(Customer customer)
        {
            return new GetAllCustomersViewModel
            (
                customer.Id,
                customer.Name,
                customer.Contact
            );
        }
    }
}
