using Rangen.Entities.POCO;
using Rangen.UseCases.UseCasesBaseClasses.CRUD;

namespace Rangen.UseCases.MarkForDeletionAndDelete
{
    public abstract class MarkBrickForDeletionRequest : CRUDRequest
    {
        public MarkBrickForDeletionRequest(int id = -1, string name = "", Item item = null) : base(id)
        {
        }

    }
}