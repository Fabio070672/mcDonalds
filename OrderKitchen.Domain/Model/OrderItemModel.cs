using System;
using System.Collections.Generic;
using System.Text;

namespace OrderKitchen.Domain.Model
{
   public class OrderItemModel
    {
        public DateTime CreateAt { get; set; }
        public Guid OrderId { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
    }
}
