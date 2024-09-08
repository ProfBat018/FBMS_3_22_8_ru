using ProductData.Models;

namespace ProductRepo.Interfaces;


public interface IOrderRepository : IRepository<Order>
{
    public void Update(Order orderRepository);
    public Task<Order> FindByIdAsync(int id);
}
