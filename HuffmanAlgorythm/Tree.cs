using System.Collections.Generic;
using System.Linq;

namespace HuffmanAlgorythm
{
    internal class Tree
    {
        private List<Node> Nodes { get; }
        private Node Top { get; set; }
        private Dictionary<char, string> Table { get; }
        private string Buffer { get; set; }
        public Tree()
        {
            Top = null;
            Nodes = new List<Node>();
            Table = new Dictionary<char, string>();
            Buffer = "";
        }

        public void AddNode(Node node) => Nodes.Add(node);

        public void BuildTree()
        {
            var sumWeight = Nodes.Sum(node => node.Weight);

            while (!Nodes.Exists(node => node.Weight == sumWeight))
            {
                var temp = new Node[2];

                for (var i = 0; i < 2; ++i)
                {
                    var result = new Node(0, (char) 0);

                    var min = 256;

                    foreach (var node in Nodes.Where(node => !node.Flag && node.Weight < min))
                    {
                        min = node.Weight;

                        result = node;
                    }

                    result.Flag = true;

                    temp[i] = result;
                }

                var newInnerNode = new Node(temp[0].Weight + temp[1].Weight, (char) 0, temp[0], temp[1]);

                Nodes.Add(newInnerNode);
            }

            Top = Nodes.Find(node => node.Weight == sumWeight);
        }

        public void TreeTraverse() => TreeTraverse(Top);

        public void TreeTraverse(Node node)
        {
            if (node.Left == null && node.Right == null)
            {
                Table[node.Symbol] = Buffer;

                Buffer = Buffer.Length <= 1 ? "" : Buffer.Remove(Buffer.Length - 1, 1);

                return;
            }

            if (node.Left != null)
            {
                Buffer += "0";

                TreeTraverse(node.Left);
            }

            if (node.Right != null)
            {
                Buffer += "1";

                TreeTraverse(node.Right);
            }

            Buffer = Buffer.Length <= 1 ? "" : Buffer.Remove(Buffer.Length - 1, 1);
        }

        public Node GetTop() => Top;

        public Dictionary<char, string> GetTable() => Table;
    }
}