using AutoMapper;
using MediatR;
using Rangen.Application.Common.Exceptions;
using Rangen.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Rangen.Application.Queries.Common
{
    public abstract class GetItemDetailQueryHandler<TQuery, TDetailVm, TEntity> : IRequestHandler<TQuery, TDetailVm>
        where TQuery : GetItemDetailQuery<TDetailVm>
    {
        protected readonly IRangenDbContext _context;
        protected readonly IMapper _mapper;

        public GetItemDetailQueryHandler(IRangenDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public abstract Task<TDetailVm> Handle(TQuery request, CancellationToken cancellationToken);


        protected TDetailVm Handle_Base(TEntity entity, TQuery request)
        {
            if (entity == null)
            {
                throw new NotFoundException(typeof(TEntity).Name, request.Id);
            }

            return _mapper.Map<TDetailVm>(entity);
        }
    }
}
