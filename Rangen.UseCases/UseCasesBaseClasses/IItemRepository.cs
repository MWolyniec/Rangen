using Rangen.Entities.POCO;
using Rangen.UseCases.UseCasesBaseClasses.CRUD;
using System.Threading.Tasks;

namespace Rangen.UseCases.UseCasesBaseClasses
{
    public interface IItemRepository
    {
        Task<CRUDGatewayResponse> Create(Item item);
        Task<CRUDGatewayResponse> Delete(Item item);

        Task<Item> FindByName(string itemName);
    }
}
