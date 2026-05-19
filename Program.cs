// See https://aka.ms/new-console-template for more information
using Interceptor.Data.Contexts;
using Interceptor.Models;

using var dbContext = new ApplicationDbContext();

var firstProduct = dbContext.Products.FirstOrDefault();

if (firstProduct == null)
    return;

dbContext.Products.Remove(firstProduct);
dbContext.SaveChanges();


Console.WriteLine("Product Deleted");
Console.WriteLine($"IsDeleted: {firstProduct.IsDeleted}");
