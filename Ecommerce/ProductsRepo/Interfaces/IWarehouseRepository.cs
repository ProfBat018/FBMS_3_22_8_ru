using ProductData.Models;
using ProductRepo.Interfaces;

namespace ProductRepo.Interfaces;


public interface IWarehouseRepository : IRepository<Warehouse>
{
    public void Update(Warehouse warehouse);
    public Task<Warehouse> FindByIdAsync(int id);
}