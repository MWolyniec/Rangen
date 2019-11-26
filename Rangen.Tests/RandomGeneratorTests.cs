using NUnit.Framework;
using Rangen.Entities.RangenCore;
using Rangen.Infrastructure.Adapters;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rangen.Tests
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

        private RangenStructureGenerator<TestItem> rangen;

        private List<TestItem> randomItems;

        [SetUp]
        public void Setup()
        {
            // fill the list of items
            testItems = new List<TestItem>();

            for (int i = 0; i < 1000; i++)
            {
                testItems.Add(new TestItem()
                {
                    Id = i,
                    RelatedItems = new List<TestItem>()
                });
            }

            randomNumbersGenerator = new RandomNumbersGeneratorAdapter() { OnlineMode = false };

            rangen = new RangenStructureGenerator<TestItem>(randomNumbersGenerator);
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
        public async Task CanGenerateStructureOfOnlyOneNodeAsync()
        {
            Node<TestItem> structure = await rangen.GenerateStructureAsync(new TestItem(), testItems, 1, 1, 50, 0).ConfigureAwait(false);
            Assert.AreEqual(1, structure.CountAllSubnodes());
        }
        [Test]
        public async Task CanGenerateStructureOfTwoNodesAsync()
        {

            Node<TestItem> structure = await rangen.GenerateStructureAsync(new TestItem(), testItems, 2, 2, 50, 0).ConfigureAwait(false);
            Assert.AreEqual(2, structure.CountAllSubnodes());
        }



        [Test]
        public async Task CanGenerateRandomStructureFromAGivenListOfItems()
        {

            TestItem mainItem = await rangen.GetOneRandomItemAsync(testItems).ConfigureAwait(false);

            Node<TestItem> generatedStructure = await rangen.GenerateStructureAsync(mainItem, testItems).ConfigureAwait(false);

            int allBranchesCount = generatedStructure.CountAllSubnodes();



            Assert.True(allBranchesCount > 1);
        }


        [Test]
        public async Task CanGenerateStructureMadeOfGivenNumberOfItemsAsync()
        {

            TestItem mainItem = await rangen.GetOneRandomItemAsync(testItems).ConfigureAwait(false);

            Node<TestItem> structureMadeOf5Items = await rangen.GenerateStructureAsync(mainItem, testItems, 5, 5, 50, 0).ConfigureAwait(false);

            Node<TestItem> structureMadeOf10Items = await rangen.GenerateStructureAsync(mainItem, testItems, 10, 10, 50, 0).ConfigureAwait(false);

            Assert.AreEqual(5, structureMadeOf5Items.CountAllSubnodes());
            Assert.AreEqual(10, structureMadeOf10Items.CountAllSubnodes());

        }
        [Test]
        public async Task CanGenerateStructureMadeOfDistinctItemsAsync()
        {
            ushort testAmount = 900;

            Node<TestItem> structure = await rangen.GenerateStructureAsync(new TestItem(), testItems, testAmount, testAmount, 50, 0).ConfigureAwait(false);
            int distinctItemsCount = structure.ListAllSubnodes().Distinct().Count();
            Assert.AreEqual(testAmount, distinctItemsCount);
        }

        [Test]
        public async Task CanListAllSubnodesAsync()
        {

            ushort testamount = 1000;
            TestItem mainItem = await rangen.GetOneRandomItemAsync(testItems).ConfigureAwait(false);

            Node<TestItem> structure = await rangen.GenerateStructureAsync(mainItem, testItems, testamount, testamount, 50, 0, true).ConfigureAwait(false);

            List<Node<TestItem>> subnodesList = structure.ListAllSubnodes();

            Assert.AreEqual(1000, subnodesList.Count);
        }

        [Test]
        public async Task CanPrepareTheItemPoolWithAnExactNumberOfItemsAsync()
        {
            var itempool = await rangen.CreateItemPoolAsync(testItems, 10, 10).ConfigureAwait(false);
            Assert.AreEqual(10, itempool.Count);
        }
        [Test]
        public async Task CanCreateLargerItemPoolThanTheGivenItemListViaMakingDuplicatesAsync()
        {
            var itempool = await rangen.CreateItemPoolAsync(testItems, 2000, 2000).ConfigureAwait(false);
            Assert.AreEqual(2000, itempool.Count);
        }

        [Test]
        public async Task CanCreateItemPoolMadeOfDistinctItemsAsync()
        {
            int testAmount = 900;

            var itempool = await rangen.CreateItemPoolAsync(testItems, testAmount, testAmount, distinct: true).ConfigureAwait(false);
            int distinctItemsCount = itempool.Distinct().Count();
            Assert.AreEqual(testAmount, distinctItemsCount);
        }
    }
}