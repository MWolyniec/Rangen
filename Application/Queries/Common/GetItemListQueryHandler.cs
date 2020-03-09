
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Rangen.Application.Common.Interfaces;
using Rangen.Application.Queries.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Rangen.Application.Queries.Common
{
    public abstract class GetItemListQueryHandler<TLookupDto> : IRequestHandler<GetItemListQuery<TLookupDto>, ItemListViewModel<TLookupDto>>
    {
        protected readonly IRangenDbContext _context;
        protected readonly IMapper _mapper;

        public GetItemListQueryHandler(IRangenDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public abstract Task<ItemListViewModel<TLookupDto>> Handle(GetItemListQuery<TLookupDto> request, CancellationToken cancellationToken);


        protected async Task<ItemListViewModel<TLookupDto>> ProjectDbSetToListAsync<TEntity>(DbSet<TEntity> dbset, CancellationToken cancellationToken) where TEntity : class
        {
            var items = await dbset.ProjectTo<TLookupDto>(_mapper.ConfigurationProvider)
                 .ToListAsync(cancellationToken);

            var vm = new ItemListViewModel<TLookupDto>
            {
                Items = items,
                Count = items.Count
            };

            return vm;
        }
    }
}