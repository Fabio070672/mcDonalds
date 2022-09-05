using OrderKitchen.Domain.Base;
using OrderKitchen.Domain.Entities;

namespace OrderKitchen.Domain.IRepository
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
    }
}
