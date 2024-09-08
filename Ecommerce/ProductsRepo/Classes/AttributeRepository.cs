using ProductData.Contexts;
using ProductData.Models;
using ProductRepo.Interfaces;
using ProductRepository.Classes;


namespace ProductRepository.Classes;

public class AttributeRepository : Repository<ProductAttribute>, IAttributeRepository
{
    public AttributeRepository(ProductContext context) : base(context)
    {
    }

    public void Update(ProductAttribute attribute)
    {
        throw new NotImplementedException();
    }

    public Task<ProductAttribute> FindByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}