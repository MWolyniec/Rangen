using Rangen.Application.Common.Mappings;
using Rangen.Application.Queries.Common;
using Rangen.Application.Queries.GetRelationTypes;
using Rangen.Domain.Entities;

namespace Rangen.Application.Queries.GetRelations
{
    public class RelationDetailVm : ItemVm, IMapFrom<Relation>
    {
        public OccurrenceLookupDto Occurrence1 { get; set; }

        public OccurrenceLookupDto Occurrence2 { get; set; }

        public RelationTypeLookupDto RelationType { get; set; }

        public float Occurrence1ChanceToOccurInTheRelation { get; set; }
        public float Occurrence2ChanceToOccurInTheRelation { get; set; }


    }
}
