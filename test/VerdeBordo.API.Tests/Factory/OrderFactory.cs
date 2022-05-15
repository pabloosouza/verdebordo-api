using Bogus;
using System;
using VerdeBordo.API.Models;
using VerdeBordo.API.Services.Responses;
using VerdeBordo.Domain.Entities.Enums;

namespace VerdeBordo.API.Tests.Factory
{
    public class OrderFactory
    {
        #region Input Models

        public static Faker<AddOrderInputModel> AddOrderInputModel =>
            new Faker<AddOrderInputModel>()
            .CustomInstantiator(x =>
            {
                return new AddOrderInputModel(
                    x.Random.Int(1,10),
                    x.Random.Float(1, 10),
                    PaymentMethod.Bill
                    );
            });

        #endregion

        #region View Models

        public static Faker<OrderViewModel> OrderViewModel =>
            new Faker<OrderViewModel>()
            .CustomInstantiator(x =>
            {
                return new OrderViewModel
                {
                    Id = Guid.NewGuid(),
                    CustomerId = Guid.NewGuid(),
                    Size = x.Random.Int(1,10),
                    Price = x.Random.Float(1, 10),
                    PaidAmount = x.Random.Float(1, 10),
                    PaymentMethod = PaymentMethod.Bill,
                    Status = OrderStatus.Quotation,
                    OrderedIn = x.Date.Past(),
                    DeliveredIn = x.Date.Future()
                };
            });

        #endregion
    }
}
