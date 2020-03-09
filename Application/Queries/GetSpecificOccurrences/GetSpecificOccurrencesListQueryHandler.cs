using AutoMapper;
using Rangen.Application.Common.Interfaces;
using Rangen.Application.Queries.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Rangen.Application.Queries.GetSpecificOccurrences
{

    public class GetSpecificOccurrencesListQueryHandler : GetItemListQueryHandler<SpecificOccurrenceLookupDto>
    {

        public GetSpecificOccurrencesListQueryHandler(IRangenDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override async Task<ItemListViewModel<SpecificOccurrenceLookupDto>> Handle(GetItemListQuery<SpecificOccurrenceLookupDto> request, CancellationToken cancellationToken)
        {
            var specificOccurrences = base._context.SpecificOccurrences;
            return await base.ProjectDbSetToListAsync(specificOccurrences, cancellationToken);
        }

    }
}

