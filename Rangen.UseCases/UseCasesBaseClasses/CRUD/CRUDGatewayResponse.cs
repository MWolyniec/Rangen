using System.Collections.Generic;

namespace Rangen.UseCases.UseCasesBaseClasses.CRUD
{
    public sealed class CRUDGatewayResponse : BaseGatewayResponse
    {
        public string Id { get; }
        public CRUDGatewayResponse(string id, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            Id = id;
        }
    }
}
