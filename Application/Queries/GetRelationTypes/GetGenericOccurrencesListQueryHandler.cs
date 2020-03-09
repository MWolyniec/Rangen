using AutoMapper;
using Rangen.Application.Common.Interfaces;
using Rangen.Application.Queries.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Rangen.Application.Queries.GetRelationTypes
{
    public class GetRelationTypesListQueryHandler : GetItemListQueryHandler<RelationTypeLookupDto>
    {

        public GetRelationTypesListQueryHandler(IRangenDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override async Task<ItemListViewModel<RelationTypeLookupDto>> Handle(GetItemListQuery<RelationTypeLookupDto> request, CancellationToken cancellationToken)
        {
            var relationTypes = base._context.RelationTypes;
            return await base.ProjectDbSetToListAsync(relationTypes, cancellationToken);
        }

    }
}

