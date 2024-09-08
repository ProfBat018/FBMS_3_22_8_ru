using System.Net.Cache;
using ProductData.Contexts;
using ProductData.Models;
using ProductRepo.Interfaces;

namespace ProductRepository.Classes;

public class CategoryRepository :Repository<Category>, ICategoryRepository
{
    public CategoryRepository(ProductContext context) : base(context)
    {
    }

    public void Update(Category category)
    {
        throw new NotImplementedException();
    }

    public Task<Category> FindByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}