using System.Linq;
using System.Threading.Tasks;

namespace Rangen.UseCases.UseCasesBaseClasses.CRUD
{
    public abstract class CRUDUseCase : ICRUDUseCase
    {
        protected readonly IItemRepository _userRepository;

        public CRUDUseCase(IItemRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public abstract Task<bool> Handle(CRUDRequest message, IOutputPort<CRUDResponse> outputPort);

        protected bool Respond(IOutputPort<CRUDResponse> outputPort, CRUDGatewayResponse response)
        {
            outputPort.Handle(response.Success ? new CRUDResponse(response.Id, true) : new CRUDResponse(response.Errors.Select(e => e.Description)));
            return response.Success;
        }
    }
}
