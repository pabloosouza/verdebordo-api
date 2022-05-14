using Microsoft.EntityFrameworkCore;
using VerdeBordo.Domain.Entities;
using VerdeBordo.Infra.Persistence.Repository.Interfaces;

namespace VerdeBordo.Infra.Persistence.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        #region Properties

        private readonly VerdeBordoContext _context;

        #endregion

        #region Constructor

        public CustomerRepository(VerdeBordoContext context)
        {
            _context = context;
        }

        #endregion

        #region Methods

        public void Add(Customer customer)
        {
            _context.Add(customer);
            _context.SaveChanges();
        }

        public void Delete(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public List<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }

        public Customer? GetById(Guid id)
        {
            return _context
                .Customers
                .Include(c => c.Addresses)
                .Include(c => c.Orders)
                .SingleOrDefault(x => x.Id == id);

        }

        #endregion

    }
}
