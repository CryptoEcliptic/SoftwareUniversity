namespace ProductShop
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using ProductShop.Data;
    using ProductShop.Dtos.Export;
    using ProductShop.Dtos.Import;
    using ProductShop.Models;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    public class StartUp
    {
        private const string UsersPath = @"../../../Datasets/users.xml";
        private const string ProductsPath = @"../../../Datasets/products.xml";
        private const string CategoryPath = @"../../../Datasets/categories.xml";
        private const string CategoryProductPath = @"../../../Datasets/categories-products.xml";

        public static void Main(string[] args)
        {
            var context = new ProductShopContext();
            Mapper.Initialize(cfg => cfg.AddProfile(new ProductShopProfile()));

            using (context)
            {
                //string inputXml = File.ReadAllText(CategoryProductPath);

                string result = GetCategoriesByProductsCount(context);

                System.Console.WriteLine(result);
            }
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(UserImportDto[]), new XmlRootAttribute("Users"));

            var deserializedUsers = (UserImportDto[])serializer.Deserialize(new StringReader(inputXml));

            List<User> usersCollection = new List<User>();

            foreach (var user in deserializedUsers)
            {
                var currentUser = Mapper.Map<User>(user);
                usersCollection.Add(currentUser);
            }

            context.Users.AddRange(usersCollection);
            context.SaveChanges();

            return $"Successfully imported {usersCollection.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(ProductImportDto[]), new XmlRootAttribute("Products"));

            var deserializedProducts = (ProductImportDto[])serializer.Deserialize(new StringReader(inputXml));

            List<Product> products = new List<Product>();

            foreach (var product in deserializedProducts)
            {
                var currentProduct = Mapper.Map<Product>(product);
                products.Add(currentProduct);
            }

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(CategoryImportDto[]), new XmlRootAttribute("Categories"));

            var deserializedCategories = (CategoryImportDto[])serializer.Deserialize(new StringReader(inputXml));

            List<Category> categories = new List<Category>();

            foreach (var category in deserializedCategories)
            {
                if (category.Name == null)
                {
                    continue;
                }
                var currentCategory = Mapper.Map<Category>(category);
                categories.Add(currentCategory);
            }

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(CategoryProductImportDto[]), new XmlRootAttribute("CategoryProducts"));

            var deserializedCategoryProducts = (CategoryProductImportDto[])serializer.Deserialize(new StringReader(inputXml));

            List<CategoryProduct> categoryProducts = new List<CategoryProduct>();

            foreach (var cp in deserializedCategoryProducts)
            {
                var validCategoryId = context.Categories.Find(cp.CategoryId);
                var validProductId = context.Products.Find(cp.ProductId);

                if (validCategoryId == null || validProductId == null)
                {
                    continue;
                }

                var categoryProduct = Mapper.Map<CategoryProduct>(cp);
                categoryProducts.Add(categoryProduct);
            }
            ;
            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .OrderBy(x => x.Price)
                .Select(x => new ProductInRangeDto
                {
                    Name = x.Name,
                    Price = x.Price,
                    Buyer = x.Buyer.FirstName + " " + x.Buyer.LastName

                })
                .Take(10)
                .ToList();

            var serializer = new XmlSerializer(typeof(List<ProductInRangeDto>), new XmlRootAttribute("Products"));

            var namespaces = new XmlSerializerNamespaces
            (
                new[] { new XmlQualifiedName("","") }
            );

            StringBuilder result = new StringBuilder();

            serializer.Serialize(new StringWriter(result), products, namespaces);

            return result.ToString().TrimEnd();
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var soldProducts = context
                .Users
                .Where(x => x.ProductsSold.Any())
                .Select(u => new UserSoldProductDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Products = u.ProductsSold.Select(x => new ProductDto
                    {
                        Name = x.Name,
                        Price = x.Price
                    })
                    .ToArray()
                })
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .ToArray();

            var serializer = new XmlSerializer(typeof(UserSoldProductDto[]), new XmlRootAttribute("Users"));

            var namespaces = new XmlSerializerNamespaces
            (
                new[] { new XmlQualifiedName("","") }
            );

            StringBuilder result = new StringBuilder();

            serializer.Serialize(new StringWriter(result), soldProducts, namespaces);

            return result.ToString().TrimEnd();


        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(x => new CategoryProductDto
                {
                    Name = x.Name,
                    Count = x.CategoryProducts.Count(),
                    AveragePrice = x.CategoryProducts.Average(y => y.Product.Price),
                    TotalRevenue = x.CategoryProducts.Sum(z => z.Product.Price)
                })
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.TotalRevenue)
                .ToArray();

            var serializer = new XmlSerializer(typeof(CategoryProductDto[]), new XmlRootAttribute("Categories"));

            var namespaces = new XmlSerializerNamespaces
            (
                new[] { new XmlQualifiedName("","") }
            );

            StringBuilder result = new StringBuilder();

            serializer.Serialize(new StringWriter(result), categories, namespaces);

            return result.ToString().TrimEnd();  
        }
    }
}