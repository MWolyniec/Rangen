using AutoMapper;
using Rangen.Application.Common.Interfaces;
using Rangen.Application.Queries.Relations.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Rangen.Application.Queries.Relations.GetGenericOccurrencesList
{
    public class GetSpecificOccurrencesListQueryHandler : GetItemListQueryHandler<GenericOccurrenceDto>
    {

        public GetSpecificOccurrencesListQueryHandler(IRangenDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override async Task<ItemListVm<GenericOccurrenceDto>> Handle(GetItemListQuery<GenericOccurrenceDto> request, CancellationToken cancellationToken)
        {
            var genericOccurrences = base._context.GenericOccurrences;
            return await base.ProjectDbSetToListAsync(genericOccurrences, cancellationToken);
        }

    }
}
