using AutoMapper;
using Rangen.Application.Common.Interfaces;
using Rangen.Application.Queries.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Rangen.Application.Queries.GetRelationTypesList
{
    public class GetRelationTypesListQueryHandler : GetItemListQueryHandler<RelationTypeDto>
    {

        public GetRelationTypesListQueryHandler(IRangenDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override async Task<ItemListVm<RelationTypeDto>> Handle(GetItemListQuery<RelationTypeDto> request, CancellationToken cancellationToken)
        {
            var relationTypes = base._context.RelationTypes;
            return await base.ProjectDbSetToListAsync(relationTypes, cancellationToken);
        }

    }
}
