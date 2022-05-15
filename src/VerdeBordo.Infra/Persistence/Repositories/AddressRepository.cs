using VerdeBordo.Domain.Entities;
using VerdeBordo.Infra.Persistence.Repositories.Interfaces;

namespace VerdeBordo.Infra.Persistence.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly VerdeBordoContext _context;

        public AddressRepository(VerdeBordoContext context)
        {
            _context = context;
        }

        public void Add(Address entity)
        {
            _context.Addresses?.Add(entity);

            _context.SaveChanges();
        }

        public void Delete(Address entity)
        {
            throw new NotImplementedException();
        }

        public List<Address> GetAll()
        {
            throw new NotImplementedException();
        }

        public Address? GetById(Guid id)
        {
            return _context.Addresses?
                .SingleOrDefault(a => a.Id == id);
        }
    }
}
