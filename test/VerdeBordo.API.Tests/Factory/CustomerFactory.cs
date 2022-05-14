using Bogus;
using VerdeBordo.Domain.Entities;

namespace VerdeBordo.API.Tests.Factory
{
    public class CustomerFactory
    {
        #region Entities

        public static Faker<Customer> Customer =>
            new Faker<Customer>()
            .CustomInstantiator(x =>
            {
                return new Customer(
                        x.Person.FullName.ToString(),
                        x.Phone.ToString()
                    );
            });

        #endregion

        #region Input Models

        public static Faker<AddCustomerInputModel> AddCustomerInputModel =>
            new Faker<AddCustomerInputModel>()
            .CustomInstantiator(x =>
            {
                return new AddCustomerInputModel
                {
                    Name = x.Person.FirstName,
                    Contact = x.Phone.ToString()
                };
            });

        #endregion
    }
}
