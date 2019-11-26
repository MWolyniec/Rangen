using NUnit.Framework;
using Rangen.Entities.POCO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rangen.Tests
{
    public class EntitiesIntegrationTests
    {
        [SetUp]
        public void Setup()
        {
            var testitem = new Brick("Main item", "A main test item");
            var testItemList = new List<Brick>();
            var testCategoryTypeList = new List<CategoryType>();
            var testCategoryList = new List<Category>();
            for (int i = 0; i < 1000; i++)
            {
                testItemList.Add(new Brick($"Item {i}", $"Test item nr {i}"));
            }

            for (int i = 0; i < 200; i++)
            {
                testCategoryList.Add(new Category($"Category {i}", $"Test category nr {i}"));
            }
            for (int i = 0; i < 10; i++)
            {
                testCategoryTypeList.Add(new CategoryType($"Category type {i}", $"Test category type nr {i}"));
            }
        }

        [Test]
        public async Task Can()
        {

        }
    }
}
