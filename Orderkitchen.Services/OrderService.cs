using OrderKitchen.Domain.IRepository;
using OrderKitchen.Domain.IServices;
using OrderKitchen.Domain.Model;
using OrderKitchen.Domain.Entities;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OrderKitchen.Repository;

namespace Orderkitchen.Services
{
    public class OrderService : IOrderService
    {

        private readonly OrderRepository orderRepository;

        public OrderService(OrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }
        public async Task<List<Order>> GetOrderAsync(bool active)
        {
            try
            {
                return await this.orderRepository.GetOrderAsync(active);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Order> GetOrderByIdAsync(Guid Id)
        {
            return await this.orderRepository.GetOrderByIdAsync(Id);
        }

        public async Task InsertAsync(OrderModel orderModel)
        {
            Order order = new Order
            {
                CreatedAt = DateTime.UtcNow,
                POS = new POS { Identification = orderModel.POSIdentification },
                Sector = new Sector { Name = orderModel.Sector }
            };
           await orderRepository.InsertAsync(order);
        }

    }
}
