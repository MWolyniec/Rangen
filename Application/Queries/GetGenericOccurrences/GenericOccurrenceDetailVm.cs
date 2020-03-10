using AutoMapper;
using Rangen.Application.Common.Mappings;
using Rangen.Application.Queries.Common;
using Rangen.Application.Queries.GetRelations;
using Rangen.Domain.Entities;
using System.Collections.Generic;

namespace Rangen.Application.Queries.GetGenericOccurrences
{
    public class GenericOccurrenceDetailVm : ItemVm, IMapFrom<GenericOccurrence>
    {
        public float GeneralChanceToOccur { get; set; }
        public List<RelationLookupDto> Relations { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<GenericOccurrence, GenericOccurrenceDetailVm>();
        }

    }
}