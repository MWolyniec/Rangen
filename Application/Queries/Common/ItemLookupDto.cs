using AutoMapper;
using Rangen.Application.Common.Mappings;
using Rangen.Domain.Common;

namespace Rangen.Application.Queries.Common
{
    public class ItemLookupDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }


    }
}
