using Rangen.Application.Common.Mappings;

namespace Rangen.Application.Queries.Relations.Common
{
    public class ItemDto : MapItemFrom
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
