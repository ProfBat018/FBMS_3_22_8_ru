using ProductData.Contexts;
using ProductData.Models;
using ProductRepo.Interfaces;
using ProductRepository.Classes;

namespace ProductsRepo.Classes;

public class ProductCategoryRepository : Repository<ProductCategory>, IProductCategoryRepository
{
    public ProductCategoryRepository(ProductContext context) : base(context)
    {
    }
}