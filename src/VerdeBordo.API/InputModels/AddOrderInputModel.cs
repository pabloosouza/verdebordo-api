using VerdeBordo.Domain.Entities.Enums;

namespace VerdeBordo.API.InputModels
{
    public record AddOrderInputModel(
        int Size,
        float Price,
        PaymentMethod PaymentMethod
        )
    { }
}
