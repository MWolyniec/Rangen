using NUnit.Framework;
using Rangen.Entities.RangenCore;
using Rangen.Infrastructure.Adapters;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rangen.API.Tests
{
    public class RandomGeneratorTests
    {
        private class TestItem
        {
            public int Id { get; set; }
            public List<TestItem> RelatedItems { get; set; }
        }

        private List<TestItem> testItems;
        private IRandomNumbersGenerator randomNumbersGenerator;

        private RangenCore<TestItem> rangen;

        private List<TestItem> randomItems;

        [SetUp]
        public void Setup()
        {
            // fill the list of items
            testItems = new List<TestItem>();

            for (int i = 0; i <= 1000; i++)
            {
                testItems.Add(new TestItem()
                {
                    Id = i,
                    RelatedItems = new List<TestItem>()
                });
            }

            randomNumbersGenerator = new RandomNumbersGeneratorAdapter() { OnlineMode = false };

            rangen = new RangenCore<TestItem>(randomNumbersGenerator);
        }


        [Test]
        public async Task CanChooseRandomItemsAsync()
        {

            randomItems = new List<TestItem>();

            for (int i = 0; i < 10; i++)
            {
                randomItems.Add(await rangen.GetOneRandomItemAsync(testItems).ConfigureAwait(false));
            }

            bool randomness = randomItems.Distinct().Count() > 1;

            Assert.True(randomness);

        }

        [Test]
        public async Task CanGenerateStructureMadeOfGivenNumberOfItems()
        {

            TestItem mainItem = await rangen.GetOneRandomItemAsync(testItems).ConfigureAwait(false);

            Node<TestItem> structureMadeOf5Items = await rangen.GenerateStructureAsync(mainItem, testItems, 5, 5, 50, 0).ConfigureAwait(false);

            Node<TestItem> structureMadeOf10Items = await rangen.GenerateStructureAsync(mainItem, testItems, 10, 10, 50, 0).ConfigureAwait(false);

            Assert.IsTrue(structureMadeOf5Items.CountAllSubnodes() + 1 == 5);
            Assert.IsTrue(structureMadeOf10Items.CountAllSubnodes() + 1 == 10);

        }


        [Test]
        public async Task CanGenerateRandomStructureFromAGivenListOfItems()
        {

            TestItem mainItem = await rangen.GetOneRandomItemAsync(testItems).ConfigureAwait(false);

            Node<TestItem> generatedStructure = await rangen.GenerateStructureAsync(mainItem, testItems).ConfigureAwait(false);

            int allBranchesCount = generatedStructure.CountAllSubnodes();

            Assert.True(allBranchesCount > 1);
        }

        //generatedStructure.BranchesCount > 0 && generatedStructure.StructureDepth > 0
    }
}