// See https://aka.ms/new-console-template for more information
using Interceptor.Data.Contexts;
using Interceptor.Models;
using Microsoft.EntityFrameworkCore;

using var dbContext = new ApplicationDbContext();

var products = dbContext.Products.IgnoreQueryFilters().ToList();
foreach (var product in products)
{
    Console.WriteLine($"Name: {product.Name}");
    Console.WriteLine($"Description: {product.Description}");
    Console.WriteLine($"Price: {product.Price}");
    Console.WriteLine($"IsDeleted: {product.IsDeleted}");
}