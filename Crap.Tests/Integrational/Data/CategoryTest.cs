using System;
using System.Linq;
using Crap.Data.Entities;
using Crap.Data.Providers;
using Crap.Data.Providers.EF;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Crap.Tests.Integrational.Data
{
    [TestClass]
    public class CategoryTest
    {
        private readonly IRepository<Category> _categoryRepository = new EfRepository<Category>();

        [TestMethod]
        public void CheckTable()
        {
            var categories = _categoryRepository.ToList();
            Assert.IsNotNull(categories);
        }

        [TestMethod]
        public void AddAndUpdateAndDelete()
        {
            var name = string.Format("Category{0}", new Random().Next(100000));
            var category = new Category
            {
                Name = name
            };
            _categoryRepository.Save(category);

            var createdCategory = _categoryRepository.SingleOrDefault(i => i.Name.Equals(name));
            Assert.IsNotNull(createdCategory);
            Assert.IsTrue(createdCategory.Id > 0);

            var newName = name.Replace("Category", "CategoryUpdated");

            createdCategory.Name = newName;

            _categoryRepository.Save(createdCategory);

            Assert.IsFalse(_categoryRepository.Any(i => i.Name.Equals(name)));
            Assert.IsTrue(_categoryRepository.Any(i => i.Name.Equals(newName)));

            _categoryRepository.Delete(createdCategory);

            Assert.IsFalse(_categoryRepository.Any(i => i.Name.Equals(name) || i.Name.Equals(newName)));
        }
        
    }
}
