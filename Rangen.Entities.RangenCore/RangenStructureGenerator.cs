using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rangen.Entities.RangenCore
{
    public class RangenStructureGenerator<T>
    {
        private readonly IRandomNumbersGenerator randomNumbersGenerator;

        public RangenStructureGenerator(IRandomNumbersGenerator randomNumbersGenerator)
        {
            this.randomNumbersGenerator = randomNumbersGenerator;
        }

        public async Task<T> GetOneRandomItemAsync(List<T> itemPool)
        {
            T item = itemPool[await randomNumbersGenerator.GetRandomNumberBetweenAsync(0, itemPool.Count)];

            return item;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mainItem"></param>
        /// <param name="mainItemPool"></param>
        /// <param name="structureMinimumItemAmount"></param>
        /// <param name="structureMaximumItemAmount">Leaving this parameter at default 0 assigns it random value.</param>
        /// <param name="subbranchingChance">Chance closer to 0 results in more same-level branches. Chance closer to 100 Results in more lower branches.</param>
        /// <returns></returns>
        /// 
        public async Task<Node<T>> GenerateStructureAsync
            (T mainItem, List<T> mainItemPool, ushort structureMinimumItemAmount = 1, ushort structureMaximumItemAmount = 0,
            byte subbranchingChance = 50, byte dryoutFactor = 34, bool distinctItems = false)
        {
            if (dryoutFactor > 100) dryoutFactor = 100;

            if (structureMaximumItemAmount > mainItemPool.Count)
                structureMaximumItemAmount = (ushort)mainItemPool.Count;
            else if (structureMaximumItemAmount == 0)
                structureMaximumItemAmount = (ushort)await randomNumbersGenerator.GetRandomNumberBetweenAsync(1, ushort.MaxValue);

            var mainNode = new Node<T>(mainItem);

            List<T> itemPool = await CreateItemPoolAsync(mainItemPool, structureMinimumItemAmount, structureMaximumItemAmount);
            var nodeList = new List<Node<T>>();

            nodeList.Add(mainNode);

            for (int i = 0; i < itemPool.Count; i++)
            {
                if (nodeList.Count == 0) break;

                ushort randomNodeIndex = (ushort)await randomNumbersGenerator.GetRandomNumberBetweenAsync(0, nodeList.Count);
                var node = nodeList[randomNodeIndex];

                int itemIndex;

                if (distinctItems)
                    itemIndex = i;
                else
                    itemIndex = await randomNumbersGenerator.GetRandomNumberBetweenAsync(0, itemPool.Count);

                var newNode = new Node<T>(itemPool[itemIndex]);
                Node<T> nodeToBranch;

                int branchesCount = node.Branches.Count;
                bool subbranch = await randomNumbersGenerator.GetRandomNumberBetweenAsync(1, 100) < subbranchingChance;
                if (subbranch && branchesCount > 0)
                {
                    int toSkip = await randomNumbersGenerator.GetRandomNumberBetweenAsync(0, branchesCount);
                    nodeToBranch = node.Branches.Skip(toSkip).Take(1).First();
                }
                else
                {
                    nodeToBranch = node;
                }

                nodeToBranch.Branches.Add(newNode);
                nodeList.Add(newNode);

                if (node.DryoutFactor < 100)
                    node.DryoutFactor += dryoutFactor;
                else
                {
                    node.DryoutFactor = 0;
                    nodeList.Remove(node);
                }
            }
            return mainNode;
        }


        public async Task<List<T>> CreateItemPoolAsync(List<T> mainPool, int minimumAmount = 1, int maximumAmount = 0, bool distinct = false)
        {
            if (maximumAmount == 0)
                maximumAmount = mainPool.Count;

            int amount = await randomNumbersGenerator.GetRandomNumberBetweenAsync(minimumAmount, maximumAmount);

            var itemPool = new List<T>();


            int mainPoolItemIndex;
            if (distinct)
            {
                if (maximumAmount > mainPool.Count) maximumAmount = mainPool.Count;
            }

            for (int i = 0; i < amount; i++)
            {

                if (distinct)
                {
                    mainPoolItemIndex = i;
                }
                else
                {
                    mainPoolItemIndex = await randomNumbersGenerator.GetRandomNumberBetweenAsync(1, mainPool.Count);
                }
                itemPool.Add(mainPool[mainPoolItemIndex]);
            }
            return itemPool;
        }

    }
}
