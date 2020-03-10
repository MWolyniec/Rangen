﻿using MediatR;
using Rangen.Application.Commands.Common;
using Rangen.Application.Common.Interfaces;
using Rangen.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Rangen.Application.Commands.Categories.DeleteCategory
{
    public class DeleteCategoryCommandHandler : DeleteItemCommandHandler<Category>
    {

        public DeleteCategoryCommandHandler(IRangenDbContext context) : base(context)
        {
        }

        public override async Task<Unit> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
        {
            return await Handle_Base(_context.Categories, request, cancellationToken);
        }
    }
}
