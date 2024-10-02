using AutoMapper;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using ProductData.Configs;
using ProductData.Contexts;
using ProductData.DTO;
using ProductData.Models;
using ProductRepo.Interfaces;
using ProductService.İnterfaces;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;


namespace ProductService.Classes;

public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IConfiguration _config;
    private readonly Mapper _mapper;

    private readonly BlobServiceClient _blobServiceClient;
    private readonly BlobContainerClient _containerClient;

    public ProductService(IUnitOfWork unitOfWork, IConfiguration config)
    {
        _unitOfWork = unitOfWork;
        _mapper = MappingConfiguration.InitializeConfig();
        _config = config;


        _blobServiceClient = new BlobServiceClient(_config["BlobConnection:ConnectionString"]);
        _containerClient = _blobServiceClient.GetBlobContainerClient(_config["BlobConnection:ContainerName"]);
    }

    public async Task<PostResponse> AddNewProductAsync(AddProductDTO newProduct, CancellationToken cancellationToken)
    {
        BlobClient blobClient = _containerClient.GetBlobClient(newProduct.imageUrl);

        try
        {
            var product = _mapper.Map<Product>(newProduct);
            product.ImageUrl = newProduct.imageUrl;

            await _unitOfWork.ProductRepository.AddAsync(product);

            await _unitOfWork.SaveAsync();

            if (newProduct.categoryIds != null)
            {
                foreach (var categoryId in newProduct.categoryIds)
                {
                    var productCategory = new ProductCategory
                    {
                        ProductId = product.ProductId,
                        CategoryId = categoryId
                    };


                    await _unitOfWork.ProductCategoryRepository.AddAsync(productCategory);
                }


                await _unitOfWork.SaveAsync();
            }

            return new PostResponse("product added", 200);
        }
        catch (OperationCanceledException)
        {
            await blobClient.DeleteIfExistsAsync(cancellationToken: cancellationToken);
            return new PostResponse("Operation was cancelled", 499);
        }
    }

public async Task<PostResponse> UploadImageAsync(IFormFile file, CancellationToken cancellationToken)
{
    try
    {
        if (file == null || file.Length == 0)
        {
            return new PostResponse("No file uploaded", 400);
        }

        var newFileName = Guid.NewGuid().ToString() + ".jpg";
        BlobClient blobClient = _containerClient.GetBlobClient(newFileName);
        
        using var stream = file.OpenReadStream();
        
        using (var image = await Image.LoadAsync(stream, cancellationToken))
        {
            using (var memoryStream = new MemoryStream())
            {
                var jpegOptions = new JpegEncoder
                {
                    Quality = 100 
                };

                await image.SaveAsJpegAsync(memoryStream, jpegOptions, cancellationToken); 
                memoryStream.Position = 0; 

                var ops = new BlobUploadOptions
                {
                    HttpHeaders = new BlobHttpHeaders
                    {
                        ContentType = "image/jpeg" 
                    }
                };

                var uploadTask = blobClient.UploadAsync(memoryStream, ops, cancellationToken);

                if (await Task.WhenAny(uploadTask, Task.Delay(TimeSpan.FromSeconds(15), cancellationToken)) == uploadTask)
                {
                    await uploadTask;
                    return new PostResponse(blobClient.Uri.ToString(), 200);
                }
                else
                {
                    return new PostResponse("Request timed out", 408);
                }
            }
        }
    }
    catch (Exception e)
    {
        return new PostResponse($"Error uploading file: {e.Message}", 500);
    }
}



    public Task LinkProductToCategories(string productName, int[] categoryIds)
    {
        throw new NotImplementedException();
    }


    public async Task<PaginatedList<ProductDTO>> GetAllPaginatedProductsAsync(int page, int pagesize)
    {
        try
        {
            var res = await _unitOfWork.ProductRepository.GetAllPaginatedAsync(page, pagesize);

            var items = _mapper.Map<IEnumerable<ProductDTO>>(res.Items);

            return new PaginatedList<ProductDTO>(items, res.TotalCount, page, pagesize);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<PaginatedList<ProductDTO>> GetAllPaginatedProductsByCategoryAsync(int page, int pagesize,
        int categoryId)
    {
        try
        {
            var productsCategories =
                await _unitOfWork.ProductCategoryRepository.GetAllAsync(c => c.CategoryId == categoryId);

            var productIds = productsCategories.Select(pc => pc.ProductId).Distinct().ToList();

            var res = await _unitOfWork.ProductRepository.GetAllPaginatedAsync(page, pagesize,
                p => productIds.Contains(p.ProductId));


            var items = _mapper.Map<IEnumerable<ProductDTO>>(res.Items);

            return new PaginatedList<ProductDTO>(items, res.TotalCount, page, pagesize);
        }
        catch (Exception)
        {
            throw;
        }
    }
}