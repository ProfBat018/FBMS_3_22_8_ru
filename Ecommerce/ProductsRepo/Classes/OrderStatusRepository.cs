using ProductData.Contexts;
using ProductData.Models;
using ProductRepo.Interfaces;

namespace ProductRepository.Classes;


public class OrderStatusRepository : Repository<OrderStatus>, IOrderStatusRepository
{
    public OrderStatusRepository(ProductContext context) : base(context)
    {
    }

    public void Update(OrderStatus orderStatus)
    {
        throw new NotImplementedException();
    }

    public Task<OrderStatus> FindByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}