using ProductData.Contexts;
using ProductData.Models;
using ProductRepo.Interfaces;

namespace ProductRepository.Classes;


public class OrderItemRepository : Repository<OrderItem>,IOrderItemRepository
{
    public OrderItemRepository(ProductContext context) : base(context)
    {
    }

    public void Update(OrderItem orderItem)
    {
        throw new NotImplementedException();
    }

    public Task<OrderItem> FindByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}

