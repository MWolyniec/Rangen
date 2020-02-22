using Rangen.Entities.PlainObjects;

namespace Rangen.Entities.ConstructionMethods
{
    public static class ConstructMethods
    {
        public static Node Add(this Node baseNode, Node nodeToAdd)
        {
            baseNode.Relations.Add(new NodeRelation(baseNode, nodeToAdd));
            return baseNode;
        }
        public static Node Add(this Node baseNode, Node nodeToAdd, RelationType relation)
        {
            baseNode.Relations.Add(new NodeRelation(baseNode, nodeToAdd, relation));
            return baseNode;
        }
    }
}
