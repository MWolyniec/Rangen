using MediatR;

namespace Rangen.Application.Queries.Common
{
    public class GetItemDetailQuery<TDetailVm> : IRequest<TDetailVm>
    {
        public int Id { get; set; }

    }
}
