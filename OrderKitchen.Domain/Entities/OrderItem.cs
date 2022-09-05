using System;
using System.Collections.Generic;
using System.Text;

namespace OrderKitchen.Domain.Entities
{
    public class OrderItem
    {
        public Guid Id { get; set; }
        public DateTime CreateAt{ get; set; }

        public Guid OrderId { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }


    }
}
