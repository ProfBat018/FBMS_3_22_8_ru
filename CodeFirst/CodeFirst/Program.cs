using CodeFirst;
using Microsoft.EntityFrameworkCore;

using TechCommerceContext context = new(); 

/*
context.Categories.AddRange(new List<Category>()
{
    new() { Name = "Laptops" },
    new() { Name = "Smartphones" },
    new() { Name = "Tablets" },
    new() { Name = "Monitors" },
    new() { Name = "Keyboards" },
    new() { Name = "Mice" },
});

context.SaveChanges();

*/

#region SecndPart



// var laptopid = context.Categories.First(x => x.Name == "Laptops").Id;


 // First - возвращает первый элемент последовательности
 //    FirstOrDefault - возвращает первый элемент последовательности или значение по умолчанию для типа, 
 //    если последовательность не содержит элементов.
 


/*
var product1 = new Product()
{
    Name = "MacBook Pro 14",
    Price = 1999.99f,
    CategoryId = laptopid
};

var product2 = new Product()
{
    Name = "Asus ROG Strix G15",
    Price = 999.99f,
    CategoryId = laptopid
};

var product3 = new Product()
{
    Name = "Lenovo Legion 5",
    Price = 799.99f,
    CategoryId = laptopid
};

var products = new List<Product>()
{
    product1,
    product2,
    product3
};

context.Products.AddRange(products);

context.SaveChanges();
*/

 #endregion

// var res = context.Categories.Where(x => x.Id >= 1);
// var query = res.ToQueryString();
// foreach(var item in res)
// {
//     Console.WriteLine(item.Name);
// }
//

 // var res = context.Categories.Where(x => x.Id >= 1).ToList();
 //
 // foreach(var item in res)
 // {
 //     Console.WriteLine(item.Name);
 // }


// var res = context.Categories.Where(x => x.Id >= 1).Select(x => new {x.Name});
//
// Console.WriteLine(res.ToQueryString());
//
// foreach(var item in res)
// {
//     Console.WriteLine(item.Name);
// }
//

 // var res = context.Categories.Where(x => x.Id >= 1).ToList().Select(x => new {x.Name});
 //
 // foreach(var item in res)
 // {
 //     Console.WriteLine(item.Name);
 // }


