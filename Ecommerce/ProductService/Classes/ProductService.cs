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
using System.Linq;
using System.Threading;

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

            var res = _unitOfWork.ProductRepository.AddAsync(product).GetAwaiter();

            if (res.IsCompleted)
            {
                return new PostResponse("Product was successfully added", 200);
            }
            else
            {
                return new PostResponse("Product wasn't added", 400);
            }
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
            BlobClient blobClient = _containerClient.GetBlobClient(file.FileName);

            using var stream = file.OpenReadStream();


            var ops = new BlobUploadOptions();
            ops.HttpHeaders.ContentType = file.ContentType;


            var uploadTask = blobClient.UploadAsync(stream, ops, cancellationToken);

            if (await Task.WhenAny(uploadTask, Task.Delay(TimeSpan.FromSeconds(15), cancellationToken)) == uploadTask)
                await uploadTask;
            else
                return new PostResponse("Request timed out", 408);

            return new PostResponse(blobClient.Uri.ToString(), 200);

        }
        catch (Exception)
        {
            throw;
        }
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

    public async Task<PaginatedList<ProductDTO>> GetAllPaginatedProductsByCategoryAsync(int page, int pagesize, int categoryId)
    {
        try
        {
            var productsCategories =
                  await _unitOfWork.ProductCategoryRepository.GetAllAsync(c => c.CategoryId == categoryId);

            var productIds = productsCategories.Select(pc => pc.ProductId).Distinct().ToList();

            var res = await _unitOfWork.ProductRepository.GetAllPaginatedAsync(page, pagesize, p => productIds.Contains(p.ProductId));


            var items = _mapper.Map<IEnumerable<ProductDTO>>(res.Items);

            return new PaginatedList<ProductDTO>(items, res.PageNumber, res.PageSize, res.TotalCount);
        }
        catch (Exception)
        {

            throw;
        }

    }
}