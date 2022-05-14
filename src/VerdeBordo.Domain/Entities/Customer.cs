namespace VerdeBordo.Domain.Entities
{
    public class Customer
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Contact { get; private set; }
        public Address? Address { get; private set; }
        public List<Embroidery> Orders { get; private set; }
        public bool IsDeleted { get; private set; }

        public Customer(string name, string contact)
        {
            Id = Guid.NewGuid();
            Name = name;
            Contact = contact;
            Orders = new List<Embroidery>();
        }

        public Customer(string name, string contact, Address address)
            : this (name, contact) 
        {
            Address = address;
        }

        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
