using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace OrderKitchen.Domain.Base
{
    public interface IBaseRepository<T> where T : class
    {
        Task InsertAsync(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        DbSet<T> Query();
    }
}
