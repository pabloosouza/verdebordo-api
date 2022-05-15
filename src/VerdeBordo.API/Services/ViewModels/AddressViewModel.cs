using VerdeBordo.Domain.Entities;

namespace VerdeBordo.API.Services.ViewModels
{
    public class AddressViewModel
    {
        public Guid Id { get; set; }
        public string Street { get; set; }
        public string? Complement { get; set; }
        public string State { get; set; }
        public string Number { get; set; }
        public string City { get; set; }

        public AddressViewModel(Guid id, string street, string? complement, string state, string number, string city)
        {
            Id = id;
            Street = street;
            Complement = complement;
            State = state;
            Number = number;
            City = city;
        }

        public static AddressViewModel Map(Address address)
        {
            return new AddressViewModel
            (
                address.Id,
                address.Street,
                address.Complement,
                address.State,
                address.Number,
                address.City
            );
        }
    }
}
