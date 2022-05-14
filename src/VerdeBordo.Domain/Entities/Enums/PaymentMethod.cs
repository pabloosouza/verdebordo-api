using System.ComponentModel.DataAnnotations;

namespace VerdeBordo.Domain.Entities.Enums
{
    public enum PaymentMethod
    {
        [Display(Name = "Transferência")]
        Transfer,

        [Display(Name = "Pix")]
        Pix,

        [Display(Name = "Boleto")]
        Bill,

        [Display(Name = "PicPay")]
        PicPay
    }
}
