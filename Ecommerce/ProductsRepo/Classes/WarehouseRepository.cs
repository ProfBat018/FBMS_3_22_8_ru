using ProductData.Contexts;
using ProductData.Models;
using ProductRepo.Interfaces;
using ProductRepository.Classes;


namespace ProductRepo.Classes;


public class WarehouseRepository : Repository<Warehouse>, IWarehouseRepository
{
    public WarehouseRepository(ProductContext context) : base(context)
    {
    }

    public void Update(Warehouse warehouse)
    {
        throw new NotImplementedException();
    }

    public Task<Warehouse> FindByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}