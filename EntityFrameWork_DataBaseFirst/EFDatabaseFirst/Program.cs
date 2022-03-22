using EFDatabaseFirst.Db;
using System;

namespace EFDatabaseFirst 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            ShowProducts();

            UpdateProductSize();

            while (Console.ReadKey().Key != ConsoleKey.Enter) { }

        }

        static void ShowProducts() // get all from Products
        {
            using (var db = new AdventureWorksDbContext())
            {
                List<Product>? products = db.Products.ToList();
                foreach (var product in products)
                {
                    Console.WriteLine($"Name : {product.Name}, Price : {product.ListPrice}");
                }
            }

        }

        static void UpdateProductSize()
        {
            using (var db = new AdventureWorksDbContext())
            {
                var product = db.Products.Find(680);
                if (product != null)
                {
                    product.Size = "60";
                }
                db.SaveChanges(false);
            }

            Console.WriteLine("Product updated ....");
        }
    }


}