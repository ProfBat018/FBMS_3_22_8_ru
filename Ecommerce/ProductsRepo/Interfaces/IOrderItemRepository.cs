using ProductData.Models;

namespace ProductRepo.Interfaces;


public interface IOrderItemRepository : IRepository<OrderItem>
{
    public void Update(OrderItem orderItem);
    public Task<OrderItem> FindByIdAsync(int id);
}

