using Bogus;
using System;
using System.Collections.Generic;
using VerdeBordo.API.InputModels;
using VerdeBordo.API.Services.ViewModels;
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
                        x.Random.Word()
                    );
            });

        #endregion

        #region Input Models

        public static Faker<AddCustomerInputModel> AddCustomerInputModel =>
            new Faker<AddCustomerInputModel>()
            .CustomInstantiator(x =>
            {
                return new AddCustomerInputModel(
                    x.Person.FirstName,
                    x.Random.Word()
                    );
            });

        #endregion

        #region View Models

        public static Faker<CustomerViewModel> GetCustomerResponse =>
            new Faker<CustomerViewModel>()
            .CustomInstantiator(x =>
            {
                return new CustomerViewModel
                (
                    Guid.NewGuid(),
                    x.Person.FullName,
                    x.Random.Word(),
                    AddressFactory.Address.Generate(3),
                    OrderFactory.Embroidery.Generate(3)
                );
            });

        #endregion
    }
}
