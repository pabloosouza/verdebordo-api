namespace VerdeBordo.Domain.Entities
{
    public class Customer
    {
        #region Properties

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Contact { get; private set; }
        public List<Address> Addresses { get; private set; }
        public List<Embroidery> Orders { get; private set; }
        public bool IsDeleted { get; private set; }

        #endregion

        #region Constructors

        public Customer(string name, string contact)
        {
            Id = Guid.NewGuid();
            Name = name;
            Contact = contact;
            Orders = new List<Embroidery>();
            Addresses = new List<Address>();
        }

        #endregion

        #region Methods

        public void Delete()
        {
            IsDeleted = true;
        }

        #endregion

    }
}
