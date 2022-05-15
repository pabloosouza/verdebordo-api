using VerdeBordo.Domain.Entities.Consts;
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
        public string PaymentMethodDescription { get; private set; }
        public OrderStatus Status { get; private set; }
        public string StatusDescription { get; private set; }
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
            PaymentMethodDescription = PaymentMethodConst.GetDescription(PaymentMethod);
            Status = OrderStatus.Quotation;
            StatusDescription = OrderStatusConst.GetDescription(Status);
            OrderedIn = DateTime.Now;
            DeliveredIn = null;
        }

        #endregion

        #region Methods

        public void UpdateStatus()
        {
            if (Status == OrderStatus.Delivered)
            {
                throw new Exception("Bordado já foi entregue.");
            }

            if (Status == OrderStatus.Delivering)
            {
                DeliveredIn = DateTime.Now;
            }

            Status++;
            StatusDescription = OrderStatusConst.GetDescription(Status);
        }

        public void Pay(float amount)
        {
            if (PaidAmount == Price)
            {
                throw new Exception("Valor total já foi pago.");
            }
            
            if (amount + PaidAmount > Price)
            {
                throw new Exception("Valor informado maior do que valor total.");
            }

            PaidAmount += amount;
        }

        #endregion
    }
}