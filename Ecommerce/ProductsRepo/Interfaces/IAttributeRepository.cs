using ProductData.Models;

namespace ProductRepo.Interfaces;

public interface IAttributeRepository : IRepository<ProductAttribute>
{
    public void Update(ProductAttribute attribute);
    public Task<ProductAttribute> FindByIdAsync(int id);
}