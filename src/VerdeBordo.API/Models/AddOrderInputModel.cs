using VerdeBordo.Domain.Entities.Enums;

namespace VerdeBordo.API.Models
{
    public record AddOrderInputModel(
        int Size,
        float Price,
        PaymentMethod PaymentMethod
        )
    { }
}
