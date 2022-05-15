using VerdeBordo.Domain.Entities;

namespace VerdeBordo.Infra.Persistence.Repositories.Interfaces
{
    public interface IOrderRepository : IBaseRepository<Embroidery>
    {
        void UpdateStatus(Guid orderId);
        void Pay(Guid orderId, float amount);   
    }
}
