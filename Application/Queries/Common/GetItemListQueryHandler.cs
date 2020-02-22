
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Rangen.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Rangen.Application.Queries.Common
{
    public abstract class GetItemListQueryHandler<TDto> : IRequestHandler<GetItemListQuery<TDto>, ItemListVm<TDto>> where TDto : ItemDto
    {
        protected readonly IRangenDbContext _context;
        protected readonly IMapper _mapper;

        public GetItemListQueryHandler(IRangenDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public abstract Task<ItemListVm<TDto>> Handle(GetItemListQuery<TDto> request, CancellationToken cancellationToken);


        protected async Task<ItemListVm<TDto>> ProjectDbSetToListAsync<TEntity>(DbSet<TEntity> dbset, CancellationToken cancellationToken) where TEntity : class
        {
            var items = await dbset.ProjectTo<TDto>(_mapper.ConfigurationProvider)
                 .ToListAsync(cancellationToken);

            var vm = new ItemListVm<TDto>
            {
                Items = items,
                Count = items.Count
            };

            return vm;
        }
    }
}