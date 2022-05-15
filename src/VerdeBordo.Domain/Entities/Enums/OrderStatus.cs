using System.ComponentModel.DataAnnotations;

namespace VerdeBordo.Domain.Entities.Enums
{
    public enum OrderStatus
    {
        Quotation,
        Draft,
        Embroidering,
        Finishing,
        Delivering,
        Delivered
    }
}
