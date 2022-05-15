using VerdeBordo.Domain.Entities.Enums;

namespace VerdeBordo.Domain.Entities.Consts
{
    public static class OrderStatusConst
    {
        public static readonly string Quotation = "Orçamento";
        public static readonly string Draft = "Rascunho";
        public static readonly string Embroidering = "Bordando";
        public static readonly string Finishing = "Acabamento";
        public static readonly string Delivering = "Em entrega";
        public static readonly string Delivered = "Entregue";

        public static string GetDescription(OrderStatus status)
        {
            return status switch
            {
                OrderStatus.Quotation => Quotation,
                OrderStatus.Draft => Draft,
                OrderStatus.Embroidering => Embroidering,
                OrderStatus.Finishing => Finishing,
                OrderStatus.Delivering => Delivering,
                OrderStatus.Delivered => Delivered,
                _ => throw new Exception("Status inválido")
            };
        }
    }
}
