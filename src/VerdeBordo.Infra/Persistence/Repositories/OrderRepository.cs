using VerdeBordo.Domain.Entities;
using VerdeBordo.Infra.Persistence.Repositories.Interfaces;

namespace VerdeBordo.Infra.Persistence.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly VerdeBordoContext _context;

        public OrderRepository(VerdeBordoContext context)
        {
            _context = context;
        }

        public void Add(Embroidery entity)
        {
            _context.Orders.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Embroidery entity)
        {
            throw new NotImplementedException();
        }

        public List<Embroidery> GetAll()
        {
            return _context.Orders.ToList();
        }

        public Embroidery? GetById(Guid id)
        {
            return _context.Orders
                    .SingleOrDefault(o => o.Id == id);
                
        }
    }
}
