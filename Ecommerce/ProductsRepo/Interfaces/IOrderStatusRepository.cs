using ProductData.Models;

namespace ProductRepo.Interfaces;


public interface IOrderStatusRepository : IRepository<OrderStatus>
{
    public void Update(OrderStatus orderStatus);
    public Task<OrderStatus> FindByIdAsync(int id);
}