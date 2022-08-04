using BlazorCRUD.Shared.Models;
using BlazorCRUD.Server.Models;
using System;
using System.Linq;

namespace BlazorCRUD.Server.Data
{
    public static class ProductDBInitializer
    {
        public static void Initialize(ApplicationDBContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Products.Any())
            {
                return;   // DB has been seeded
            }
            List<Product> Products = new List<Product>
            {
                    new Product {  Name = "Laptop", Price = 20.02, Quantity = 10, Description ="This is a best gaming laptop"},
                    new Product {  Name = "Microsoft Office", Price = 20.99, Quantity = 50, Description ="This is a Office Application"},
                    new Product {  Name = "Lazer Mouse", Price = 12.02, Quantity = 20, Description ="The mouse that works on all surface"},
                    new Product {  Name = "USB Storage", Price = 5.00, Quantity = 20, Description ="To store 256GB of data"}
            };
            foreach (Product product in Products)
            {
                context.Products.Add(product);
            }
            context.SaveChanges();
        }
    }
}