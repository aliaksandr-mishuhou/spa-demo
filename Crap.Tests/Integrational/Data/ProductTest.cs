using System;
using System.Linq;
using Crap.Data.Entities;
using Crap.Data.Providers;
using Crap.Data.Providers.EF;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Crap.Tests.Integrational.Data
{
    [TestClass]
    public class ProductTest
    {
        private readonly IRepository<Product> _productRepository = new EfRepository<Product>();
        private readonly IRepository<Category> _categoryRepository = new EfRepository<Category>();

        [TestMethod]
        public void CheckTable()
        {
            var items = _productRepository.ToList();
            Assert.IsNotNull(items);
        }

        [TestMethod]
        public void AddAndUpdateAndDelete()
        {
            var category = new Category
            {
                Name = string.Format("Category{0}", new Random().Next(100000))
            };

            _categoryRepository.Save(category);

            var name = string.Format("Product{0}", new Random().Next(100000));
            var product = new Product
            {
                Name = name,
                CategoryId = category.Id
            };
            _productRepository.Save(product);

            var createdProduct = _productRepository.SingleOrDefault(i => i.Name.Equals(name));
            Assert.IsNotNull(createdProduct);
            Assert.IsTrue(createdProduct.Id > 0);

            var newName = name.Replace("Product", "ProductUpdated");

            createdProduct.Name = newName;

            _productRepository.Save(createdProduct);

            Assert.IsFalse(_productRepository.Any(i => i.Name.Equals(name)));
            Assert.IsTrue(_productRepository.Any(i => i.Name.Equals(newName)));

            _productRepository.Delete(createdProduct);

            Assert.IsFalse(_productRepository.Any(i => i.Name.Equals(name) || i.Name.Equals(newName)));

            _categoryRepository.Delete(category);
        }
    }
}
