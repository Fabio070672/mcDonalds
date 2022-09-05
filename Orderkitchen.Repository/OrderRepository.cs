using Microsoft.EntityFrameworkCore;
using OrderKitchen.Domain.Base;
using OrderKitchen.Domain.Entities;
using OrderKitchen.Domain.IRepository;
using OrderKitchen.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderKitchen.Repository
{
    public class OrderRepository : BaseRepository<Order> , IOrderRepository 
    {

        public OrderRepository(DataContext context) : base(context)
        {

        }

        public Task InsertAsync(Order entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> GetOrderAsync(bool active)
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetOrderByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
