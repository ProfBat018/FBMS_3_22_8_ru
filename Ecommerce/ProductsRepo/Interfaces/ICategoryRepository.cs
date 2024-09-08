using System.Net.Cache;
using ProductData.Models;

namespace ProductRepo.Interfaces;

public interface ICategoryRepository : IRepository<Category>
{
    public void Update(Category category);
    public Task<Category> FindByIdAsync(int id);
}