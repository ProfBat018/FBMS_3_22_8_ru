using Microsoft.AspNetCore.Mvc;
using ProductRepo.Interfaces;
using RestSharp;

namespace TechCommerce.Controllers;

public class ProductController : Controller
{
    public async  Task<IActionResult> Index()
    {
        var client = new RestClient("https://localhost:7007");
        
        var request = new RestRequest("Products/All", Method.Get);
        
        var response = await client.ExecuteAsync(request);
        
        if (response.IsSuccessful)
        {
            Console.WriteLine(response.Content);
        }
        
        
        return View();
    }
}