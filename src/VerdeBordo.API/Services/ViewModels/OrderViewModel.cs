using VerdeBordo.Domain.Entities;

namespace VerdeBordo.API.Services.ViewModels
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }
        public int Size { get; set; }
        public float Price { get; set; }
        public float AmountToPay { get; set; }
        public string? PaymentMethodDescription { get; set; }
        public string? StatusDescription { get; set; }
        public DateTime OrderedIn { get; set; }
        public DateTime? DeliveredIn { get; set; }

        public static OrderViewModel Map(Embroidery embroidery)
        {
            return new OrderViewModel
            {
                Id = embroidery.Id,
                Size = embroidery.Size,
                Price = embroidery.Price,
                AmountToPay = embroidery.Price - embroidery.PaidAmount,
                PaymentMethodDescription = embroidery.PaymentMethodDescription,
                StatusDescription = embroidery.StatusDescription,
                OrderedIn = embroidery.OrderedIn,
                DeliveredIn = embroidery.DeliveredIn
            };
        }

    }
}
