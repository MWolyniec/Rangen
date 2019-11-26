using System.Collections.Generic;

namespace Rangen.Entities.RangenCore
{
    public class Node<T>
    {
        public T MainItem { get; }
        public Node<T> CurrentBranch { get; }
        public List<Node<T>> Branches { get; }

        public byte DryoutFactor { get; set; }

        public Node(Node<T> currentBranch, T mainItem)
        {
            CurrentBranch = currentBranch;
            MainItem = mainItem;
            Branches = new List<Node<T>>();
        }

        public Node(T mainItem)
        {
            MainItem = mainItem;
            CurrentBranch = this;
            Branches = new List<Node<T>>();
        }

        public int CountAllSubnodes()
        {
            int subnodesCount = 0;
            if (Branches.Count > 0)
            {
                subnodesCount = Branches.Count;
                foreach (var branch in Branches)
                {
                    subnodesCount += branch.CountAllSubnodes();
                }
            }
            return subnodesCount;
        }

        public List<Node<T>> ListAllSubnodes()
        {
            List<Node<T>> subnodes = new List<Node<T>>();

            foreach (var branch in Branches)
            {
                subnodes.Add(branch);
                subnodes.AddRange(branch.ListAllSubnodes());
            }
            return subnodes;
        }
    }
}
