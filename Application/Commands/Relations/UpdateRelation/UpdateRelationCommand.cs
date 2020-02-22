using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Rangen.Application.Common.Exceptions;
using Rangen.Application.Common.Interfaces;
using Rangen.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Rangen.Application.Commands.Upsert
{
    public class UpdateRelationCommand : IRequest<int>
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public class UpdateRelationCommandHandler : IRequestHandler<UpdateRelationCommand, int>
        {
            private readonly IRangenDbContext _context;
            private readonly IMapper _mapper;

            public UpdateRelationCommandHandler(IRangenDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<int> Handle(UpdateRelationCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Relations.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);


                _ = entity ?? throw new NotFoundException(nameof(Relation), request.Id);



                entity = _mapper.Map<UpdateRelationCommand, Relation>(request, entity);


                await _context.SaveChangesAsync(cancellationToken);

                return entity.Id;
            }
        }
    }
}
