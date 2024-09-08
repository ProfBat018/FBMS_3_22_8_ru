using ProductData.Contexts;
using ProductData.Models;
using ProductRepo.Interfaces;


namespace ProductRepository.Classes;


public class AttributeValueRepository : Repository<AttributeValue>, IAttributeValueRepository
{
    public AttributeValueRepository(ProductContext context) : base(context)
    {
    }

    public void Update(AttributeValue attributeValue)
    {
        throw new NotImplementedException();
    }

    public Task<AttributeValue> FindByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}




