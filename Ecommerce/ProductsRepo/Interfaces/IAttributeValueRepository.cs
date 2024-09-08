using ProductData.Models;

namespace ProductRepo.Interfaces;


public interface IAttributeValueRepository : IRepository<AttributeValue>
{
    public void Update(AttributeValue attributeValue);
    public Task<AttributeValue> FindByIdAsync(int id);
}




