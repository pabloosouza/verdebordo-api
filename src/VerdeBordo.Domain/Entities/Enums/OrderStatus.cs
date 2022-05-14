using System.ComponentModel.DataAnnotations;

namespace VerdeBordo.Domain.Entities.Enums
{
    public enum OrderStatus
    {
        [Display(Name = "Orçamento")]
        Quotation,

        [Display(Name = "Rascunho")]
        Draft,

        [Display(Name = "Bordando")]
        Embroidering,

        [Display(Name = "Acabamento")]
        Finishing,

        [Display(Name = "Em entrega")]
        Delivering,

        [Display(Name = "Entregue")]
        Delivered
    }
}
