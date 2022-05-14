using Bogus;
using System;
using System.Collections.Generic;
using VerdeBordo.API.Models;
using VerdeBordo.API.Services.Responses;
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
                return new AddCustomerInputModel(
                    x.Person.FirstName,
                    x.Phone.ToString()
                    );
            });

        #endregion

        #region Responses

        public static Faker<GetCustomerResponse> GetCustomerResponse =>
            new Faker<GetCustomerResponse>()
            .CustomInstantiator(x =>
            {
                return new GetCustomerResponse
                {
                    Id = Guid.NewGuid(),
                    Name = x.Person.FullName,
                    Contact = x.Phone.ToString(),
                    Addresses = new List<Address>(),
                    Orders = new List<Embroidery>()
                };
            });

        #endregion
    }
}
