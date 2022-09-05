using System;
using System.Collections.Generic;
using System.Text;

namespace OrderKitchen.Domain.Entities
{
 public class Employee
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
