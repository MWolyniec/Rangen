using Rangen.Entities.POCO;
using Rangen.UseCases.UseCasesBaseClasses.CRUD;
using System.Collections.Generic;

namespace Rangen.UseCases.RegisterAndCreate
{
    public class RegisterBrickRequest : CRUDRequest
    {
        public List<Category> Categories { get; set; }
        public List<Brick> Parents { get; set; }
        public List<Brick> Children { get; set; }

        public RegisterBrickRequest(string name, string description,
            List<Category> categories, List<Brick> parents, List<Brick> children) : base(name, description)
        {
            Categories = categories;
            Parents = parents;
            Children = children;
        }


    }
}
