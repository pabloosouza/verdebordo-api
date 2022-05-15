using VerdeBordo.Domain.Entities;

namespace VerdeBordo.Infra.Persistence.Repositories.Interfaces
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        void Order(Embroidery embroidery);
    }
}
