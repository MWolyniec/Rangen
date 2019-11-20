using System.Collections.Generic;

namespace Rangen.Entities.RangenCore
{
    public class Node<T>
    {
        public T MainItem { get; }
        public Node<T> CurrentBranch { get; }
        public Dictionary<string, Node<T>> Branches { get; }

        public byte DryoutFactor { get; set; }

        public Node(Node<T> currentBranch, T mainItem)
        {
            CurrentBranch = currentBranch;
            MainItem = mainItem;
            Branches = new Dictionary<string, Node<T>>();
        }

        public Node(T mainItem)
        {
            MainItem = mainItem;
            CurrentBranch = this;
            Branches = new Dictionary<string, Node<T>>();
        }

        public int CountAllSubnodes()
        {
            int subnodesCount = Branches.Count;
            if (Branches.Count > 0)
            {
                foreach (var branch in Branches)
                {
                    subnodesCount += CountAllSubnodes();
                }
            }
            return subnodesCount;
        }
    }
}
