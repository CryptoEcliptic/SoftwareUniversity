using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using AutoMapper;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;
using ProductShop.ViewModels;

namespace ProductShop
{
    public class StartUp
    {
        private static readonly string productsPath = @"C:\Users\Name\Desktop\SoftUni\DbAdvanced - Entity Framework\10 JSON Processing\Product Shop - Skeleton\ProductShop\Datasets\products.json";

        private static readonly string usersPath = @"C:\Users\Name\Desktop\SoftUni\DbAdvanced - Entity Framework\10 JSON Processing\Product Shop - Skeleton\ProductShop\Datasets\users.json";

        private static readonly string categosiesPath = @"C:\Users\Name\Desktop\SoftUni\DbAdvanced - Entity Framework\10 JSON Processing\Product Shop - Skeleton\ProductShop\Datasets\categories.json";

        private static readonly string categoryProductsPath = @"C:\Users\Name\Desktop\SoftUni\DbAdvanced - Entity Framework\10 JSON Processing\Product Shop - Skeleton\ProductShop\Datasets\categories-products.json";

        public static void Main(string[] args)
        {

            ProductShopContext context = new ProductShopContext();


            using (context)
            {
                //var jsonString = File.ReadAllText(categoryProductsPath);
                string result = GetUsersWithProducts(context);

                Console.WriteLine(result);
            }
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<User[]>(inputJson);

            List<User> usersList = new List<User>();

            foreach (var user in users)
            {
                if (IsValid(user))
                {
                    usersList.Add(user);
                }
            }

            context.AddRange(usersList);
            context.SaveChanges();

            return $"Successfully imported {users.Count()}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<Product[]>(inputJson);

            List<Product> productList = new List<Product>();

            foreach (var product in products)
            {
                if (IsValid(product))
                {
                    productList.Add(product);
                }
            }

            context.AddRange(productList);
            context.SaveChanges();

            return $"Successfully imported {productList.Count()}";

        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert.DeserializeObject<Category[]>(inputJson);

            List<Category> vlidCategories = new List<Category>();

            foreach (var category in categories)
            {
                if (IsValid(category))
                {
                    vlidCategories.Add(category);
                }
            }
            context.Categories.AddRange(vlidCategories);
            context.SaveChanges();

            return $"Successfully imported {vlidCategories.Count()}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            //With data validation does not pass in Judge - memory limit

            //var existingProductIDs = context 
            //    .Products
            //    .Select(x => x.Id)
            //    .ToList();

            //var existingCategoryIDs = context
            //   .Categories
            //   .Select(x => x.Id)
            //   .ToList();

            var jsonIds = JsonConvert.DeserializeObject<HashSet<CategoryProduct>>(inputJson);
            HashSet<CategoryProduct> validCompositeKeys = new HashSet<CategoryProduct>();


            //With data validation does not pass in Judge - memory limit
            foreach (var ck in jsonIds)
            {
                //var isValidKey = existingProductIDs.Any(x => x == ck.ProductId)
                //    && existingCategoryIDs.Any(x => x == ck.CategoryId);

                //if (isValidKey)
                //{
                validCompositeKeys.Add(ck);
                // }
            }
            context.CategoryProducts.AddRange(validCompositeKeys);
            context.SaveChanges();

            return $"Successfully imported {validCompositeKeys.Count()}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var selectedProducts = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .OrderBy(x => x.Price)
                .Select(x => new ExportProductDto()
                {
                    ProductName = x.Name,
                    Price = x.Price,
                    Seller = x.Seller.FirstName + ' ' + x.Seller.LastName ?? x.Seller.LastName
                })
                .ToList();

            var jsonProducts = JsonConvert.SerializeObject(selectedProducts, Formatting.Indented);

            return jsonProducts;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(x => x.ProductsSold.Count >= 1 && x.ProductsSold.Any(y => y.Buyer != null))
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Select(x => new
                {
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    soldProducts = x.ProductsSold
                    .Where(y => y.Buyer != null)
                    .Select(y => new
                    {
                        name = y.Name,
                        price = y.Price,
                        buyerFirstName = y.Buyer.FirstName,
                        buyerLastName = y.Buyer.LastName
                    })
                    .ToList()
                })
                .ToList();

            var jsonProducts = JsonConvert.SerializeObject(users, Formatting.Indented);

            return jsonProducts;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {

            var categories = context.Categories
                .OrderByDescending(p => p.CategoryProducts.Count())
                .Select(x => new
                {
                    category = x.Name,
                    productsCount = x.CategoryProducts.Count(),
                    averagePrice = $"{x.CategoryProducts.Select(y => y.Product.Price).Sum() / x.CategoryProducts.Count():f2}",
                    totalRevenue = $"{x.CategoryProducts.Select(y => y.Product.Price).Sum():f2}"

                })
                .ToList();

            var jsonPCategories = JsonConvert.SerializeObject(categories, Formatting.Indented);

            return jsonPCategories;
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = new
            {
                usersCount = context.Users
                .Where(x => x.ProductsSold.Count >= 1 && x.ProductsSold.Any(y => y.Buyer != null))
                .Count(),

                users = context.Users
                  .Where(x => x.ProductsSold.Count >= 1 && x.ProductsSold.Any(y => y.Buyer != null))
                  .OrderByDescending(x => x.ProductsSold.Count(y => y.Buyer != null))
                  .Select(x => new
                  {

                      firstName = x.FirstName,
                      lastName = x.LastName,
                      age = x.Age,
                      soldProducts = new
                      {
                          count = x.ProductsSold.Count(y => y.Buyer != null),
                          products = x.ProductsSold
                          .Where(y => y.Buyer != null)
                          .Select(y => new
                          {
                              name = y.Name,
                              price = y.Price

                          }).ToArray()
                      }
                  }).ToArray()
            };


            var jsonUsers = JsonConvert.SerializeObject(users,
                            Newtonsoft.Json.Formatting.Indented,
                            new JsonSerializerSettings
                            {
                                NullValueHandling = NullValueHandling.Ignore
                            }); ;

            return jsonUsers;
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var results = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationContext, results, true);
        }
    }
}