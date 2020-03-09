using AutoMapper;
using Rangen.Application.Common.Interfaces;
using Rangen.Application.Queries.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Rangen.Application.Queries.GetRelations
{
    public class GetRelationsListQueryHandler : GetItemListQueryHandler<RelationLookupDto>
    {

        public GetRelationsListQueryHandler(IRangenDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override async Task<ItemListViewModel<RelationLookupDto>> Handle(GetItemListQuery<RelationLookupDto> request, CancellationToken cancellationToken)
        {
            var relations = base._context.Relations;
            return await base.ProjectDbSetToListAsync(relations, cancellationToken);
        }


    }
}
