using System;
using System.Collections.Generic;
using System.Text;

namespace OrderKitchen.Domain.Entities
{
   public class Sector
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Active { get; set; }
    }
}
