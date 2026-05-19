// See https://aka.ms/new-console-template for more information
using Interceptor.Data.Contexts;
using Interceptor.Models;

using var dbContext = new ApplicationDbContext();

List<Product> newProducts =
    [
        new Product { Name = "Product 1", Description = "Description 1", Price = 10.00m },
        new Product { Name = "Product 2", Description = "Description 2", Price = 20.00m },
        new Product { Name = "Product 3", Description = "Description 3", Price = 30.00m }
    ];


dbContext.Products.AddRange(newProducts);
dbContext.SaveChanges();

var products = dbContext.Products.ToList();
foreach (var product in products)
{
    Console.WriteLine($"Name: {product.Name}");
    Console.WriteLine($"Description: {product.Description}");
    Console.WriteLine($"Price: {product.Price}");
    Console.WriteLine($"IsDeleted: {product.IsDeleted}");
}