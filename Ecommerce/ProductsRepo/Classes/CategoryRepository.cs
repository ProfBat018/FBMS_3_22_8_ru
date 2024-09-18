using System.Net.Cache;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using ProductData.Contexts;
using ProductData.Models;
using ProductRepo.Interfaces;

namespace ProductRepository.Classes;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    private readonly ProductContext _context;
    public CategoryRepository(ProductContext context) : base(context)
    {
        _context = context;
    }

    public void Update(Category category)
    {
        throw new NotImplementedException();
    }

    public Task<Category> FindByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Category> FindByNameAsync(string name)
    {
       return await _context.Categories.FirstOrDefaultAsync(c => c.Name == name);
    }
}