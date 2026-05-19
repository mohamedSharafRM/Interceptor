// See https://aka.ms/new-console-template for more information
using Interceptor.Data.Contexts;
using Interceptor.Models;

using var dbContext = new ApplicationDbContext();

var product1 = new Product
{
    Name = "Laptop",
    Description = "Gaming Laptop",
    Price = 19500m
};

dbContext.Products.Add(product1);
dbContext.SaveChanges();

Console.WriteLine("Product added successfully.");
Console.WriteLine($"Product ID: {product1.Id}");
Console.WriteLine($"Product Name: {product1.Name}");
Console.WriteLine($"Product Description: {product1.Description}");
Console.WriteLine($"Product Price: {product1.Price.ToString("N0")}");
Console.WriteLine($"Product Created At: {product1.CreatedAt}");
Console.WriteLine($"Product Updated At: {product1.UpdatedAt}");
Console.WriteLine($"Product IsDeleted: {product1.IsDeleted}");

product1.Price = 25000m;
dbContext.SaveChanges();
Console.WriteLine("Product updated successfully.");
Console.WriteLine($"Product Price: {product1.Price.ToString("N0")}");
Console.WriteLine($"Product updated at : {product1.UpdatedAt}");
