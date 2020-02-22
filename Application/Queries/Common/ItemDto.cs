using Rangen.Application.Common.Mappings;

namespace Rangen.Application.Queries.Common
{
    public class ItemDto : MapItemFrom
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
