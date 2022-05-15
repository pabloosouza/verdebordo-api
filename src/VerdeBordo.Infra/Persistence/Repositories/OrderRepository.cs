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
            _context.Orders?.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Embroidery entity)
        {
            throw new NotImplementedException();
        }

        public List<Embroidery> GetAll()
        {
#pragma warning disable CS8604 // Possible null reference argument.
            return _context.Orders.ToList();
#pragma warning restore CS8604 // Possible null reference argument.
        }

        public Embroidery? GetById(Guid id)
        {
            return _context.Orders?
                    .SingleOrDefault(o => o.Id == id);
                
        }

        public void UpdateStatus(Guid id)
        {
            var order = _context.Orders?
                    .SingleOrDefault(o => o.Id == id);

            order?.UpdateStatus();

            _context.SaveChanges();
        }
    }
}
