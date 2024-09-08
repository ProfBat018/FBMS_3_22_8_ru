using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductRepo.Interfaces;


namespace ProductRepo.Interfaces;

public interface IUnitOfWork
{
    public IAttributeRepository AttributeRepository { get; }
    public IAttributeValueRepository AttributeValueRepository { get; }
    public ICategoryRepository CategoryRepository { get; }
    public IOrderItemRepository OrderItemRepository { get; }
    public IOrderStatusRepository OrderStatusRepository { get; }
    public IOrderRepository OrderRepository { get; }
    public IProductRepository ProductRepository { get; }
    public IWarehouseRepository WarehouseRepository { get; }
    void Save();
    Task SaveAsync();
}
