using System;
using System.Collections.Generic;
using System.Text;

namespace OrderKitchen.Domain.Entities
{
  public  class Order
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public bool Active { get; set; }
        public POS POS { get; set; }
        public Guid EmployeeId { get; set; }
        public Sector Sector { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
