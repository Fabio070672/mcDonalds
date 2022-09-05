using System;
using System.Collections.Generic;
using System.Text;

namespace OrderKitchen.Domain.Model
{
   public class OrderModel
    {
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
        public bool Active { get; set; }
        public string POSIdentification { get; set; }
        public Guid EmployeeId { get; set; }
        public string Sector { get; set; }
        public List<OrderItemModel> OrderItems { get; set; }
    }
}
