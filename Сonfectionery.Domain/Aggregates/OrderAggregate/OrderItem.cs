﻿using System;
using Сonfectionery.Domain.Seedwork;

namespace Сonfectionery.Domain.Aggregates.OrderAggregate
{
    public class OrderItem : Entity
    {
        public Guid PieId { get; private set; }
        public Guid OrderId { get; private set; }

        public decimal UnitPrice { get; private set; }
        public decimal Discount { get; private set; }
        public int Units { get; private set; }

        public decimal TotalPrice => Units * UnitPrice;

        private OrderItem()
        {

        }

        public static OrderItem Create(Guid pieId, decimal unitPrice, decimal discount, int units = 1)
        {
            if (units <= 0)
            {
                throw new ArgumentException("Invalid number of units");
            }

            if ((unitPrice * units) < discount)
            {
                throw new ArgumentException("The total of order item is lower than applied discount");
            }

            return new OrderItem
            {
                PieId = pieId,
                UnitPrice = unitPrice,
                Discount = discount,
                Units = units
            };
        }

        public void AddDiscount(decimal discount)
        {
            if (discount < 0)
            {
                throw new ArgumentException("Invalid discount");
            }

            if ((UnitPrice * Units) < discount)
            {
                throw new ArgumentException("The total of order item is lower than applied discount");
            }

            Discount = discount;
        }

        public void AddUnits(int units)
        {
            if (units < 0)
            {
                throw new ArgumentException("Invalid units");
            }

            Units += units;
        }
    }
}
