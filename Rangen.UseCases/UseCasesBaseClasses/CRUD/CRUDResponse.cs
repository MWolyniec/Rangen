using System.Collections.Generic;

namespace Rangen.UseCases.UseCasesBaseClasses.CRUD
{
    public class CRUDResponse : UseCaseResponseMessage
    {
        public string Id { get; }
        public IEnumerable<string> Errors { get; }

        public CRUDResponse(IEnumerable<string> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public CRUDResponse(string id, bool success = false, string message = null) : base(success, message)
        {
            Id = id;
        }
    }
}
