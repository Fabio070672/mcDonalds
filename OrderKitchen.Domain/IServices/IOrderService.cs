using OrderKitchen.Domain.Entities;
using OrderKitchen.Domain.IRepository;
using OrderKitchen.Domain.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderKitchen.Domain.IServices
{
    public interface IOrderService 
    {
        Task<Order> GetOrderByIdAsync(Guid Id);
        Task InsertAsync(OrderModel order);
        Task<List<Order>> GetOrderAsync(bool active);
    }
}
