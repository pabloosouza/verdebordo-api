namespace VerdeBordo.API.InputModels
{
    public record AddAddressInputModel(string Street, string? Complement, string Sate, string Number, string City)
    {
    }
}
