using Bogus;
using System;
using VerdeBordo.API.InputModels;
using VerdeBordo.API.Services.ViewModels;
using VerdeBordo.Domain.Entities;

namespace VerdeBordo.API.Tests.Factory
{
    public class AddressFactory
    {
        #region Entities

        public static Faker<Address> Address =>
            new Faker<Address>()
            .CustomInstantiator(x =>
            {
                return new Address(
                    Guid.NewGuid(),
                    x.Random.Word(),
                    x.Random.Word(),
                    x.Random.Word(),
                    x.Random.Word(),
                    x.Random.Word()
                    );
            });

        #endregion

        #region Input Models

        public static Faker<AddAddressInputModel> AddAddressInputModel =>
            new Faker<AddAddressInputModel>()
            .CustomInstantiator(x =>
            {
                return new AddAddressInputModel(
                    x.Random.Word(),
                    x.Random.Word(),
                    x.Random.Word(),
                    x.Random.Word(),
                    x.Random.Word()
                    );
            });

        #endregion

        #region View Models

        public static Faker<AddressViewModel> AddressViewModel =>
            new Faker<AddressViewModel>()
            .CustomInstantiator(x =>
            {
                return new AddressViewModel
                (
                    Guid.NewGuid(),
                    x.Random.Word(),
                    x.Random.Word(),
                    x.Random.Word(),
                    x.Random.Word(),
                    x.Random.Word()
                );
            });

        #endregion
    }
}
