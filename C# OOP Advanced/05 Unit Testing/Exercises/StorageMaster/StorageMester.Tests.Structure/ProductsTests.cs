using NUnit.Framework;
using StorageMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace StorageMester.Tests.Structure
{
    [TestFixture]
    public class ProductsTests
    {

        private Type product;

        [SetUp]
        public void Setup()
        {
            this.product = this.GetType("Product");
        }

        [Test]
        public void ValidateAllProducts()
        {
            string[] products = new string[]
            {
            "Gpu", "HardDrive", "Product", "Ram", "SolidStateDrive"
            };

            foreach (var product in products)
            {
                var currentType = GetType(product);

                Assert.That(currentType, Is.Not.Null, $"{currentType} doesn't exists");
            }
        }

        [Test]
        public void ValidateConstructors()
        {
            BindingFlags flags = BindingFlags.NonPublic | BindingFlags.Instance;

            ConstructorInfo constructor = this.product
                .GetConstructors(flags)
                .FirstOrDefault();

            Assert.That(constructor, Is.Not.Null, "Constructor doesn't exist");

            var parameters = constructor.GetParameters();

            Assert.That(parameters[0].ParameterType, Is.EqualTo(typeof(double)), "Parameter" +
                " should be of type double");
            Assert.That(parameters[1].ParameterType, Is.EqualTo(typeof(double)), "Parameter" +
                " should be of type double");
        }

        [Test]
        public void ValidateProductChildClasses()
        {
            Type[] childrenClasses = new Type[] 
            {
                GetType("Ram"),
                GetType("HardDrive"),
                GetType("SolidStateDrive"),
                GetType("Gpu"),
            };

            foreach (var child in childrenClasses)
            {
                Assert.That(child.BaseType, Is.EqualTo(product), $"{child} doesn't " +
                    $"inherit {product}!");
            }
        }

        [Test]
        public void ValidateProperties()
        {
            PropertyInfo[] actualProps = product.GetProperties();

            Dictionary<string, Type> expectedProps = new Dictionary<string, Type>
            {
                { "Price", typeof(double)},
                { "Weight", typeof(double)}
            };

            foreach (var prop in actualProps)
            {
                bool validProperty = expectedProps.Any(x => x.Key == prop.Name &&
                x.Value == prop.PropertyType);

                Assert.That(validProperty, "Not a valid property");
            }
        }

        [Test]
        public void ValidateProductFields()
        {
            var priceField = product.GetField("price", BindingFlags.NonPublic |
                BindingFlags.Instance);

            Assert.That(priceField, Is.Not.Null, "No field with name product");
        }

        [Test]
        public void ValidateProductIsAbstractClass()
        {
            Assert.That(product.IsAbstract, $"Product class must be abstract!");
        }

        private Type GetType(string product)
        {
            Type targetType = typeof(StartUp)
                .Assembly
                .GetTypes()
                .FirstOrDefault(t => t.Name == product);

            return targetType;
        }
    }
}
