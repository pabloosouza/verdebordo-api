using VerdeBordo.Domain.Entities;

namespace VerdeBordo.API
{
    public class AddCustomerInputModel
    {
        public string Name { get; set; }
        public string Contact { get; set; }
        public Address? Address { get; set; }
    }
}
