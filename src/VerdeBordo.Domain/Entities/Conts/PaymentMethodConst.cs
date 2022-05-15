using VerdeBordo.Domain.Entities.Enums;

namespace VerdeBordo.Domain.Entities.Consts
{
    public static class PaymentMethodConst
    {
        public static readonly string Transfer = "Transferência";
        public static readonly string Pix = "Pix";
        public static readonly string Bill = "Boleto";
        public static readonly string PicPay = "PicPay";

        public static string GetDescription(PaymentMethod method)
        {
            return method switch
            {
                PaymentMethod.Transfer => Transfer,
                PaymentMethod.Pix => Pix,
                PaymentMethod.Bill => Bill,
                PaymentMethod.PicPay => PicPay,
                _ => throw new Exception("Método de pagamento inválido.")
            };
        }
    }
}
