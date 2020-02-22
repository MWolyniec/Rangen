using AutoMapper;
using Rangen.Application.Queries.Common;
using Rangen.Domain.Common;

namespace Rangen.Application.Common.Mappings
{
    public class MapItemFrom : IMapFrom<Item>
    {

        public virtual void Mapping(Profile profile)
        {
            profile.CreateMap<Item, ItemDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name));
        }
    }
}
