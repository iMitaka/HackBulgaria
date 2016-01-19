using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQSolutions
{
    public class Program
    {
        public static void Main()
        {
            var productsList = new List<Product>();
            productsList.Add(new Product() { Id = 50, CategoryId = 100, Name = "Cola" });
            productsList.Add(new Product() { Id = 70, CategoryId = 100, Name = "Fanta" });
            productsList.Add(new Product() { Id = 80, CategoryId = 100, Name = "Sprite" });
            productsList.Add(new Product() { Id = 150, CategoryId = 150, Name = "JimBeam" });

            var someCategory = new Category() { Id = 100, Name = "Napitki" };
            foreach (var product in productsList)
            {
                product.Category = someCategory;
            }

            productsList.Add(new Product() { Id = 150, CategoryId = 180, Name = "Hamburger", Category = new Category() { Name = "Alaminut" } });

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Products with Ids between 1 and 100:");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();

            var newProductsList = GetProducts(productsList);

            foreach (var product in newProductsList)
            {
                Console.WriteLine(string.Format("Product Name: {0}, Id:{1}", product.Name, product.Id));
            }
            Console.WriteLine();

            var categorisList = new List<Category>();
            categorisList.Add(new Category() { Id = 100, Name = "Napitki" });
            categorisList.Add(new Category() { Id = 150, Name = "Alkohol" });
            categorisList.Add(new Category() { Id = 199, Name = "Hranitelni Stoki" });
            categorisList.Add(new Category() { Id = 250, Name = "Aksesuari" });

            foreach (var category in categorisList)
            {
                category.Products = productsList;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Categoris with Ids between 101 and 200:");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();

            var newCategoriesList = GetCategories(categorisList);

            foreach (var category in newCategoriesList)
            {
                Console.WriteLine(string.Format("Category Name: {0}, Id:{1}", category.Name, category.Id));
            }
            Console.WriteLine();

            var ordersList = new List<Order>();
            ordersList.Add(new Order() { Id = 300, Name = "Poruchka 1", OrderDate = DateTime.Now, Products = productsList });
            ordersList.Add(new Order() { Id = 301, Name = "Poruchka 2", OrderDate = DateTime.Now, Products = newProductsList });
            ordersList.Add(new Order() { Id = 200, Name = "Poruchka 3", OrderDate = DateTime.Now, Products = newProductsList });
            ordersList.Add(new Order() { Id = 250, Name = "Poruchka 4", OrderDate = DateTime.Now, Products = productsList });

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Orders with Ids between 201 and 300:");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();

            var newOrdersList = GetOrders(ordersList);

            foreach (var order in newOrdersList)
            {
                Console.WriteLine(string.Format("Order Name: {0}, Id:{1}", order.Name, order.Id));
                Console.WriteLine("Products:");
                foreach (var product in order.Products)
                {
                    Console.WriteLine("-{0}", product.Name);
                }
                Console.WriteLine();
            }
            Console.WriteLine();


            // Queries Tasks:

            // Create linq query which returns all products with ids between 15 and 30:
            productsList.Where(p => p.Id >= 15 && p.Id <= 30);

            // Create linq query which returns all categories with ids between 105 and 125:
            categorisList.Where(c => c.Id >= 105 && c.Id <= 125);

            // Create linq query which returns first 15 orders sorted by order name:
            ordersList.OrderBy(o => o.Name).Take(15);

            // Create linq query which returns first 3 orders which contains a specific productId (e.g. 10). 
            // Orders must be sorted based on OrderDate Then print order names.
            var customOrders = ordersList.Where(o => o.Products.Any(p => p.Id == 150)).OrderBy(o => o.OrderDate).Take(3).ToList();
            // Poruchka 1 and Poruchka 4 contains a product "JimBeam" with Id == 150:
            foreach (var order in customOrders)
            {
                Console.WriteLine(order.Name);
            }
            Console.WriteLine();

            // Create linq query which returns all product with the name of the category which they belong to. 
            // Order the result based on CategoryName The result must be printed to the console:
            var customProductsList = productsList.OrderBy(p => p.Category.Name);
            foreach (var product in customProductsList)
            {
                Console.WriteLine("Product: " + product.Name + ", Category: " + product.Category.Name);
            }
            Console.WriteLine();

            // Create linq query which returns all categories together with their products
            // Create class CategoryWithProduct which should keep the result:
            List<CategoryWithProduct> categoriesWithProducts = categorisList
                 .Select(c => new CategoryWithProduct
             {
                 CategoryId = c.Id,
                 CategoryName = c.Name,
                 ProductNames = c.Products.Select(p => p.Name).ToList(),
             }).ToList();

            foreach (var categoryWithProduct in categoriesWithProducts)
            {
                Console.WriteLine("Name: " + categoryWithProduct.CategoryName + ", Id:" + categoryWithProduct.CategoryId);
                foreach (var productName in categoryWithProduct.ProductNames)
                {
                    Console.WriteLine("-" + productName);
                }
            }
            Console.WriteLine();

            // Create linq query which selects all orders together with their products and then print it to the screen.
            // For every product print its category name as well. Sort the result by orderDate.
            var customOrderList = ordersList.OrderBy(o => o.OrderDate).ToList();
            foreach (var order in customOrderList)
            {
                Console.WriteLine("{0}:",order.Name);
                foreach (var product in order.Products)
                {
                    Console.WriteLine("{0} - {1}",product.Category.Name,product.Name);
                }
            }
        }

        public static List<Product> GetProducts(List<Product> productsList)
        {
            // returns a list with all products, ProductIds should be between 1 and 100

            var newList = productsList.Where(p => p.Id >= 1 && p.Id <= 100).ToList();
            return newList;
        }

        public static List<Category> GetCategories(List<Category> categoriesList)
        {
            // returns a list with all categories, CategoriesIds should be between 101 and 200

            var newList = categoriesList.Where(c => c.Id >= 101 && c.Id <= 200).ToList();
            return newList;
        }

        public static List<Order> GetOrders(List<Order> ordersList)
        {
            // returns a list with all orders, OrderIds should be between 201 and 300

            var newList = ordersList.Where(o => o.Id >= 201 && o.Id <= 300).ToList();
            return newList;
        }
    }
}
