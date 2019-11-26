using Rangen.Entities.POCO;
using Rangen.UseCases.UseCasesBaseClasses;
using Rangen.UseCases.UseCasesBaseClasses.CRUD;
using System.Threading.Tasks;

namespace Rangen.UseCases.RegisterAndCreate
{
    public class RegisterBrickUseCase : CRUDUseCase
    {

        public RegisterBrickUseCase(IItemRepository userRepository) : base(userRepository)
        {
        }

        public override async Task<bool> Handle(CRUDRequest message, IOutputPort<CRUDResponse> outputPort)
        {
            RegisterBrickRequest request = (RegisterBrickRequest)message;
            CRUDGatewayResponse response = await _userRepository.Create(new Brick(request.Name, request.Description, request.Categories, request.Parents, request.Children));
            return Respond(outputPort, response);
        }
    }
}
