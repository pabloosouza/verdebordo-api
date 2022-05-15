﻿using VerdeBordo.Domain.Entities;
using VerdeBordo.Domain.Entities.Enums;

namespace VerdeBordo.API.Services.ViewModels
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }
        public int Size { get; set; }
        public float Price { get; set; }
        public float PaidAmount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime OrderedIn { get; set; }
        public DateTime? DeliveredIn { get; set; }

        public static OrderViewModel Map(Embroidery embroidery)
        {
            return new OrderViewModel
            {
                Id = embroidery.Id,
                Size = embroidery.Size,
                Price = embroidery.Price,
                PaidAmount = embroidery.PaidAmount,
                PaymentMethod = embroidery.PaymentMethod,
                Status = embroidery.Status,
                OrderedIn = embroidery.OrderedIn,
                DeliveredIn = embroidery.DeliveredIn
            };
        }

    }
}
