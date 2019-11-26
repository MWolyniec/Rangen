using Rangen.Entities.POCO;

namespace Rangen.UseCases.UseCasesBaseClasses.CRUD
{
    public class CRUDRequest : IUseCaseRequest<CRUDResponse>
    {
        public string Name { get; }
        public string Description { get; }
        public int Id { get; }
        public Item Item { get; }

        public CRUDRequest(string name, string description)
        {
            Name = name;
            Description = description;
        }
        public CRUDRequest(string name)
        {
            Name = name;
        }
        public CRUDRequest(int id)
        {
            Id = id;
        }
        public CRUDRequest(Item item)
        {
            Item = item;
        }
    }
}
