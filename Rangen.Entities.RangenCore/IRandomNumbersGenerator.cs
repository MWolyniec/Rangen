using System.Threading.Tasks;

namespace Rangen.Entities.RangenCore
{
    public interface IRandomNumbersGenerator
    {
        Task<int> GetRandomNumberBetweenAsync(int minimumValue, int maximumValue);

        public bool OnlineMode { get; set; }
    }
}
