using Microsoft.EntityFrameworkCore;
using OrderKitchen.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderKitchen.Repository.Context
{
   public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<POS> POs { get; set; }
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Employee> Employees { get; set; }

    }
}
