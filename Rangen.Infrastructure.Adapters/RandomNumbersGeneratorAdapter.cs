using Rangen.Entities.RangenCore;
using System.Threading.Tasks;

namespace Rangen.Infrastructure.Adapters
{
    public class RandomNumbersGeneratorAdapter : IRandomNumbersGenerator
    {
        public bool OnlineMode { get; set; }

        private Random.Org.Random externalGenerator;

        public RandomNumbersGeneratorAdapter()
        {
            externalGenerator = new Random.Org.Random();
        }

        public async Task<int> GetRandomNumberBetweenAsync(int minimumValue, int maximumValue)
        {
            externalGenerator.UseLocalMode = !OnlineMode;
            return OnlineMode ? await Task.Run(() => externalGenerator.Next(minimumValue, maximumValue)) : externalGenerator.Next(minimumValue, maximumValue);
        }
    }
}
