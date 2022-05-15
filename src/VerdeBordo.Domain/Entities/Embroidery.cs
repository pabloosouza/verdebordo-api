using VerdeBordo.Domain.Entities.Enums;

namespace VerdeBordo.Domain.Entities
{
    public class Embroidery
    {
        #region Properties

        public Guid Id { get; private set; }
        public Guid CustomerId { get; private set; }
        public int Size { get; private set; }
        public float Price { get; private set; }
        public float PaidAmount { get; private set; }
        public PaymentMethod PaymentMethod { get; private set; }
        public OrderStatus Status { get; private set; }
        public DateTime OrderedIn { get; private set; }
        public DateTime? DeliveredIn { get; private set; }

        #endregion

        #region Constructors

        public Embroidery(Guid customerId, int size, float price, PaymentMethod paymentMethod)
        {
            Id = Guid.NewGuid();
            CustomerId = customerId;
            Size = size;
            Price = price;
            PaymentMethod = paymentMethod;
            Status = OrderStatus.Quotation;
            OrderedIn = DateTime.Now;
            DeliveredIn = null;
        }

        #endregion
    }
}