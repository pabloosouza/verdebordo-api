namespace VerdeBordo.Domain.Entities
{
    public class Address
    {
        #region Properties

        public Guid Id { get; private set; }
        public Guid CustomerId { get; private set; }
        public string Street { get; private set; }
        public string Complement { get; private set; }
        public string State { get; private set; }
        public string Number { get; private set; }

        #endregion

        #region Constructors
        public Address(string street, string complement, string state, string number)
        {
            Id = Guid.NewGuid();
            Street = street;
            Complement = complement;
            State = state;
            Number = number;
        }

        #endregion

    }
}